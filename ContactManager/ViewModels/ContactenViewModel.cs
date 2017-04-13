﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Model;

namespace ContactManager.ViewModels
{
    public class ContactenViewModel
    {

        public IEnumerable<Contact> Contacten { get; set; }

        public string Filter { get; set; }

        public int ActiefContactId { get; set; }

        public Contact ActiefContact { get; set; }
    }
}