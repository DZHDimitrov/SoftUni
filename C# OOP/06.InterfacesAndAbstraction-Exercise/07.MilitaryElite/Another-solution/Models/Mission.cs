using MilitaryElite.Common.Enums;
using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string state;

        public Mission(string codeName,string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; set; }

        public string State 
        {
            get
            {
                return this.state;
            }
            set
            {
                if (!Enum.TryParse<State>(value,false,out _))
                {
                    throw new ArgumentException("Invalid mission state");
                }
                this.state = value;
            }
        }

        public void CompleteMission()
        {
            if (this.State == "Finished")
            {
                throw new ArgumentException("Invalid mission state");
            }
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
