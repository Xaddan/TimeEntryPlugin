using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;

namespace TimeEntryPlugin.UnitTest
{
   [TestClass]
   public class TimeEntryTest
   {
      [TestMethod]
      public void CreateTimeEntry_RequiredAmountIsCreated_True()
      {
         var addDays = 5;
         var guid = Guid.NewGuid();
         var target = new TimeEntry
         {
            Id = guid,
            Start = DateTime.Today,
            End = DateTime.Today.AddDays(addDays),
         };

         var pluginContext = new XrmFakedPluginExecutionContext
         {
            InputParameters = new ParameterCollection { { "Target", target } },
            MessageName = "Create",
            InitiatingUserId = Guid.NewGuid()
         };

         var fakeContext = new XrmFakedContext
         {
            ProxyTypesAssembly = Assembly.GetAssembly(typeof(TimeEntry))
         };

         fakeContext.Initialize(target);
         fakeContext.ExecutePluginWith<Plugin>(pluginContext);

         List<TimeEntry> timeEntries = fakeContext.CreateQuery<TimeEntry>().Where(t => t.Id != guid).ToList();

         Assert.IsTrue(timeEntries.Count == addDays + 1);
      }

      [TestMethod]
      public void CreateTimeEntry_TimeCheck_True()
      {
         var addDays = 5;
         var guid = Guid.NewGuid();
         var target = new TimeEntry
         {
            Id = guid,
            Start = DateTime.Today,
            End = DateTime.Today.AddDays(addDays),
         };

         var pluginContext = new XrmFakedPluginExecutionContext
         {
            InputParameters = new ParameterCollection { { "Target", target } },
            MessageName = "Create",
            InitiatingUserId = Guid.NewGuid()
         };

         var fakeContext = new XrmFakedContext
         {
            ProxyTypesAssembly = Assembly.GetAssembly(typeof(TimeEntry))
         };

         fakeContext.Initialize(target);
         fakeContext.ExecutePluginWith<Plugin>(pluginContext);

         List<TimeEntry> timeEntries = fakeContext.CreateQuery<TimeEntry>().Where(t => t.Id != guid).ToList();

         Assert.IsTrue(timeEntries[0].Start == target.Start);
         Assert.IsTrue(timeEntries[0].Start == timeEntries[0].End);
      }
      
      [TestMethod]
      public void CreateTimeEntry_IdCheck_True()
      {
         var addDays = 5;
         var guid = Guid.NewGuid();
         var target = new TimeEntry
         {
            Id = guid,
            Start = DateTime.Today,
            End = DateTime.Today.AddDays(addDays),
         };

         var pluginContext = new XrmFakedPluginExecutionContext
         {
            InputParameters = new ParameterCollection { { "Target", target } },
            MessageName = "Create",
            InitiatingUserId = Guid.NewGuid()
         };

         var fakeContext = new XrmFakedContext
         {
            ProxyTypesAssembly = Assembly.GetAssembly(typeof(TimeEntry))
         };

         fakeContext.Initialize(target);
         fakeContext.ExecutePluginWith<Plugin>(pluginContext);

         List<TimeEntry> timeEntries = fakeContext.CreateQuery<TimeEntry>().Where(t => t.Id != guid).ToList();

         Assert.IsTrue(timeEntries[0].Id != guid);
      }

      [TestMethod]
      public void CreateTimeEntry_TargetCheck_False()
      {
         var addDays = 5;
         var guid = Guid.NewGuid();
         var target = new TimeEntry
         {
            Id = guid,
            Start = DateTime.Today,
            End = DateTime.Today.AddDays(addDays),
         };

         var pluginContext = new XrmFakedPluginExecutionContext
         {
            InputParameters = new ParameterCollection { { "", target } },
            MessageName = "Create",
            InitiatingUserId = Guid.NewGuid()
         };

         var fakeContext = new XrmFakedContext
         {
            ProxyTypesAssembly = Assembly.GetAssembly(typeof(TimeEntry))
         };

         fakeContext.Initialize(target);
         fakeContext.ExecutePluginWith<Plugin>(pluginContext);

         List<TimeEntry> timeEntries = fakeContext.CreateQuery<TimeEntry>().Where(t => t.Id != guid).ToList();

         Assert.IsTrue(timeEntries.Count == 0);
      }

      [TestMethod]
      public void CreateTimeEntry_RequiredAmountIsNotCreated_False()
      {
         var addDays = 0;
         var guid = Guid.NewGuid();
         var target = new TimeEntry
         {
            Id = guid,
            Start = DateTime.Today,
            End = DateTime.Today.AddDays(addDays),
         };

         var pluginContext = new XrmFakedPluginExecutionContext
         {
            InputParameters = new ParameterCollection { { "Target", target } },
            MessageName = "Create",
            InitiatingUserId = Guid.NewGuid()
         };

         var fakeContext = new XrmFakedContext
         {
            ProxyTypesAssembly = Assembly.GetAssembly(typeof(TimeEntry))
         };

         fakeContext.Initialize(target);
         fakeContext.ExecutePluginWith<Plugin>(pluginContext);

         List<TimeEntry> timeEntries = fakeContext.CreateQuery<TimeEntry>().Where(t => t.Id != guid).ToList();

         Assert.IsTrue(timeEntries.Count == 0);
      }
   }
}