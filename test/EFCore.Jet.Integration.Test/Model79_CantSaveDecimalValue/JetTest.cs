﻿using System;
using System.Data.Common;
using System.Data.Jet;
using System.Data.OleDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCore.Jet.Integration.Test.Model79_CantSaveDecimalValue
{
    [TestClass]
    public class Model79_CantSaveDecimalValue : Test
    {
        protected override DbConnection GetConnection()
        {
            return Helpers.GetJetConnection();
        }
    }
}
