using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Tests
{
    static class MockDataBuilder

    {

        public static List<Model.Entities.HicksNationalAccount> GetAccounts()
        {

            return JsonConvert.DeserializeObject<List<Model.Entities.HicksNationalAccount>>(File.ReadAllText(Constants.ACCOUNTS));
        }
        public static List<Model.Entities.HicksNationalAccountOwner> GetAccountOwners()
        {
            return JsonConvert.DeserializeObject<List<Model.Entities.HicksNationalAccountOwner>>(File.ReadAllText(Constants.OWNERS));
        }
        public static List<Model.Entities.HicksNationalAccountType> GetAccountTypes()
        {
            return JsonConvert.DeserializeObject<List<Model.Entities.HicksNationalAccountType>>(File.ReadAllText(Constants.ACCOUNTTYPES));
        }
        public static List<Model.Entities.HicksNationalAccountOwnerLinkage> GetAccountLinkages()
        {
            return JsonConvert.DeserializeObject<List<Model.Entities.HicksNationalAccountOwnerLinkage>>(File.ReadAllText(Constants.ACCOUNTLINKAGES));
        }
    }
}
