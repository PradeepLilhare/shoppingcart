using ShoppingBAL;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingWebModule.Controllers
{
    public class StateController : Controller
    {
        StateMasterBAL _objstateBAL = new StateMasterBAL();
        public ActionResult Index(List<StateModel> _listStateMaster)
        {
            List<StateModel> _listproduct = new List<StateModel>();
            _listStateMaster = _objstateBAL.StateMastersList(_listproduct);
            return View(_listStateMaster);
        }

        [HttpGet]
        public ActionResult SaveUpdateState(int intStateId)
        {
            StateModel _viewStateModal = new StateModel();
            _viewStateModal.intStateId = intStateId;

            List<CountryModel> _listCountry = new List<CountryModel>();

            _listCountry = _objstateBAL.GetCountry();

            if (_viewStateModal.intStateId != 0)
                _viewStateModal = _objstateBAL.GetStateById(_viewStateModal);

            _viewStateModal._listCountry = _listCountry;
            return View(_viewStateModal);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveUpdateState(StateModel _viewStateModel)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {

                List<CountryModel> _listCountry = new List<CountryModel>();
                _listCountry = _objstateBAL.GetCountry();

                _viewStateModel._listCountry = _listCountry;

                if (_viewStateModel.intStateId == 0)
                    _objstateBAL.SaveState(_viewStateModel);
                else
                    _objstateBAL.UpdateState(_viewStateModel);

                ModelState.AddModelError("", _viewStateModel.StatusMessaage);
            }
            ModelState.Clear();
            return RedirectToAction("Index", "State");
        }
        [HttpGet]
        public ActionResult DeleteState(int intStateId)
        {
            _objstateBAL.DeleteState(intStateId);
            return RedirectToAction("Index", "State");
        }
    }
}
