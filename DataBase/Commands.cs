using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionTools.DataBase
{
    public class Commands
    {
        private Dictionary<string, object> _params;
        private bool _stored;
        private string _query;

        public Commands(string query, bool isStoredProcedure = false)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentNullException("Query can't be null");
            }
            _query = query;
            _stored = isStoredProcedure;
            _params = new Dictionary<string, object>();
        }

        public Dictionary<string, object> Params
        {
            get
            {
                return _params;
            }
        }

        public bool Stored
        {
            get
            {
                return _stored;
            }
        }

        public string Query
        {
            get
            {
                return _query;
            }

        }

        public void AddParameter(string parameterName, object value)
        {
            if (parameterName == null || parameterName.Trim().Length == 0)
            {
                throw new ArgumentNullException("Parameter can't be null");
            }

            if (_params.ContainsKey(parameterName))
            {
                throw new MissingMemberException("Parameter {0} already exist", parameterName);
            }
            _params.Add(parameterName, value ?? DBNull.Value);
        }
    }
}
