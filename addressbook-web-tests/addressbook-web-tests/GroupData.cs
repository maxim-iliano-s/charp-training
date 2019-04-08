﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";

		public GroupData(string name)
        {
            this.name = name;
        }

        public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }


		public string Name
        {
            get
            {
                return name;
            }
			set
            {
                this.name = value;
            }

		}

        public string Header
        {
            get
            {
                return header;
            }
			set
            {
                this.header = value;
            }
        }

        public string Footer { get => footer; set => footer = value; }

    }
}