﻿using System;
using Hyland.Unity;
using HylandAddons.WorkView;
using HylandAddonsTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace HylandAddonsTests
{
    [TestClass]
    public class ObjectEquatableTests
    {
        [TestMethod]
        public void MultiKeysEqual()
        {
            long objectId = 8046003;

            using (var app = Application.Connect(Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var glAccount = new GeneralLedgerAccount();
                glAccount.Company = "FAK";
                glAccount.COACode = "COA";
                glAccount.GLAccount1 = "5585|750|486A";

                var wvObject = app.WorkView.Applications.Find("APA")?.Classes.Find("GeneralLedgerAccount")?.GetObjectByID(objectId);

                var result = ObjectEquatable.IsMatch(glAccount, wvObject);

                Assert.IsNotNull(wvObject);
                Assert.IsTrue(result);
            }

        }

        [TestMethod]
        public void MultiKeysNotEqual()
        {
            long objectId = 8046003;

            using (var app = Application.Connect(Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var glAccount = new GeneralLedgerAccount();
                glAccount.Company = "FHT";
                glAccount.COACode = "COA";
                glAccount.GLAccount1 = "5585|750|486A";

                var wvObject = app.WorkView.Applications.Find("APA")?.Classes.Find("GeneralLedgerAccount")?.GetObjectByID(objectId);

                var result = ObjectEquatable.IsMatch(glAccount, wvObject);

                Assert.IsNotNull(wvObject);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void SingleKeyEqual()
        {
            long objectId = 8131978;

            using (var app = Application.Connect(Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var invoice = new Invoice();
                invoice.InvoiceNum = "00220711";
                invoice.InvoiceAmount = 10.00M;

                var wvObject = app.WorkView.Applications.Find("APA")?.Classes.Find("POInvoice")?.GetObjectByID(objectId);

                var result = ObjectEquatable.IsMatch(invoice, wvObject);

                Assert.IsNotNull(wvObject);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void SingleKeyNotEqual()
        {
            long objectId = 8131978;

            using (var app = Application.Connect(Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var invoice = new Invoice();
                invoice.InvoiceNum = "ZZZ999ZZZ999";
                invoice.InvoiceAmount = 10.00M;

                var wvObject = app.WorkView.Applications.Find("APA")?.Classes.Find("POInvoice")?.GetObjectByID(objectId);

                var result = ObjectEquatable.IsMatch(invoice, wvObject);

                Assert.IsNotNull(wvObject);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void NotOptionalEqual()
        {
            long objectId = 8131978;

            using (var app = Application.Connect(Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var invoice = new Invoice();
                invoice.InvoiceNum = "00220711";
                invoice.Company = "FAK";
                invoice.VendorId = "RELH01";
                invoice.InvoiceAmount = 10.00M;

                var wvObject = app.WorkView.Applications.Find("APA")?.Classes.Find("POInvoice")?.GetObjectByID(objectId);

                var result = ObjectEquatable.IsMatch(invoice, wvObject, WorkViewMatchType.NonOptional);

                Assert.IsNotNull(wvObject);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void NotOptionalNotEqual()
        {
            long objectId = 8131978;

            using (var app = Application.Connect(Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var invoice = new Invoice();
                invoice.InvoiceNum = "ZZZ999ZZZ999";
                invoice.Company = "FAK";
                invoice.VendorId = "RELH01";
                invoice.InvoiceAmount = 10.00M;

                var wvObject = app.WorkView.Applications.Find("APA")?.Classes.Find("POInvoice")?.GetObjectByID(objectId);

                var result = ObjectEquatable.IsMatch(invoice, wvObject, WorkViewMatchType.NonOptional);

                Assert.IsNotNull(wvObject);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void AllAttributesEqual()
        {
            long objectId = 8131978;

            using (var app = Application.Connect(Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var invoice = new Invoice();
                invoice.InvoiceNum = "00220711";
                invoice.Company = "FAK";
                invoice.VendorId = "RELH01";
                invoice.InvoiceAmount = 420.00M;

                var wvObject = app.WorkView.Applications.Find("APA")?.Classes.Find("POInvoice")?.GetObjectByID(objectId);

                var result = ObjectEquatable.IsMatch(invoice, wvObject, WorkViewMatchType.NonOptional);

                Assert.IsNotNull(wvObject);
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void AllAttributesNotEqual()
        {
            long objectId = 8131978;

            using (var app = Application.Connect(Application.CreateOnBaseAuthenticationProperties(
                ConfigurationManager.AppSettings["ServiceUrl"],
                ConfigurationManager.AppSettings["LoginUsername"],
                ConfigurationManager.AppSettings["LoginPassword"],
                ConfigurationManager.AppSettings["Datasource"])))
            {
                var invoice = new Invoice();
                invoice.InvoiceNum = "ZZZ999ZZZ999";
                invoice.Company = "FAK";
                invoice.VendorId = "RELH01";
                invoice.InvoiceAmount = 420.00M;

                var wvObject = app.WorkView.Applications.Find("APA")?.Classes.Find("POInvoice")?.GetObjectByID(objectId);

                var result = ObjectEquatable.IsMatch(invoice, wvObject, WorkViewMatchType.NonOptional);

                Assert.IsNotNull(wvObject);
                Assert.IsFalse(result);
            }
        }
    }
}
