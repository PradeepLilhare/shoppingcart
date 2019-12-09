using ShoppingCore.ShoppingWebRepository;
using ShoppingDataModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBAL
{
   public class StateMasterBAL
    {
        StateMasterDataAccess _dataaccess = new StateMasterDataAccess();

        public List<StateModel> StateMastersList(List<StateModel> _listState)
        {
            return _dataaccess.StateMastersList(_listState);
        }
        public StateModel SaveState(StateModel _objState)
        {
            return _dataaccess.SaveState(_objState);
        }
        public StateModel UpdateState(StateModel _objState)
        {
            return _dataaccess.UpdateState(_objState);
        }
        public StateModel DeleteState(int intStateId)
        {
            return _dataaccess.DeleteState(intStateId);
        }
        public List<CountryModel> GetCountry()
        {
            return _dataaccess.GetCountry();
        }
       
        public StateModel GetStateById(StateModel _Statemodal)
        {
            return _dataaccess.GetStateById(_Statemodal);
        }
    }
}
