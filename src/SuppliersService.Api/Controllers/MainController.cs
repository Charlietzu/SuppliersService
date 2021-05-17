using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SuppliersService.Business.Interfaces;
using SuppliersService.Business.Notifications;
using System;
using System.Linq;

namespace SuppliersService.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificator _notificator;
        public readonly IUser AppUser;

        protected Guid UserId { get; set; }
        protected bool UserAuthenticated { get; set; }

        protected MainController(INotificator notificator, IUser appUser)
        {
            _notificator = notificator;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UserId = appUser.GetUserId();
                UserAuthenticated = true;
            }
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!ModelState.IsValid) NotifyErrorInvalidModel(modelState);
            return CustomResponse();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (!_notificator.HasNotification())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                error = _notificator.GetNotifications().Select(n => n.Message)
            });
        }

        protected void NotifyErrorInvalidModel(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (ModelError error in errors)
            {
                string errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string message)
        {
            _notificator.Handle(new Notification(message));
        }
    }
}