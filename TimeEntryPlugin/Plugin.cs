using System;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace TimeEntryPlugin
{
   public class Plugin : IPlugin
   {
      public void Execute(IServiceProvider serviceProvider)
      {
         ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

         IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

         if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity entity)
         {
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

            try
            {
               if (entity.LogicalName == "msdyn_timeentry")
               {
                  TimeEntry timeEntry = entity.ToEntity<TimeEntry>();

                  if (timeEntry?.Start != null && timeEntry.End != null)
                  {
                     TimeSpan amountDays = (TimeSpan) (timeEntry.Start - timeEntry.End)?.Duration();

                     if (amountDays.Days > 0)
                     {
                        for (int i = 0; i <= amountDays.Days; i++)
                        {
                           TimeEntry newTimeEntry = (TimeEntry)service.Retrieve(entity.LogicalName, entity.Id, new ColumnSet(true));
                           newTimeEntry.Attributes.Remove("statecode");
                           newTimeEntry.Id = Guid.NewGuid();
                           newTimeEntry.Start = timeEntry.Start?.AddDays(i);
                           newTimeEntry.End = timeEntry.Start?.AddDays(i);

                           service.Create(newTimeEntry);
                        }
                     }
                  }
               }
            }
            catch (FaultException<OrganizationServiceFault> ex)
            {
               throw new InvalidPluginExecutionException("An error occurred in TimeEntryPlugin.", ex);
            }
            catch (Exception ex)
            {
               tracingService.Trace($"TimeEntryPlugin: {ex}");
               throw;
            }
         }
      }
   }
}