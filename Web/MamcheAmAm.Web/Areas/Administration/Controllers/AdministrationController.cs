namespace MamcheAmAm.Web.Areas.Administration.Controllers
{
    using MamcheAmAm.Common;
    using MamcheAmAm.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
