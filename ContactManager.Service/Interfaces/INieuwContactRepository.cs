﻿using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Model;

namespace ContactManager.Service.Interfaces
{
    interface INieuwContactRepository
    {
        void Bewaar();
        void VoegContactToe(Contact contact);
        void VoegContactToeEnBewaar(Contact contact);

    }
}