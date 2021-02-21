using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace TimeEntryPlugin
{
	/// <summary>
	/// Сущность, используемая для записи времени.
	/// </summary>
	[DataContract]
	[EntityLogicalName("msdyn_timeentry")]
	public class TimeEntry : Entity, INotifyPropertyChanging, INotifyPropertyChanged
	{
      #region Constants

      public const string EntityLogicalName = "msdyn_timeentry";

      public const string EntityLogicalCollectionName = "msdyn_timeentries";

      public const string EntitySetName = "msdyn_timeentries";

      public const int EntityTypeCode = 10334;

      #endregion

      #region Events

      public event PropertyChangedEventHandler PropertyChanged;

      public event PropertyChangingEventHandler PropertyChanging;

      #endregion

      #region Constructor

      /// <summary>
      /// Default Constructor.
      /// </summary>
      public TimeEntry() : base(EntityLogicalName)
      {
      }

      #endregion

      #region Properties

      /// <summary>
      /// Уникальный идентификатор пользователя, создавшего запись.
      /// </summary>
      [AttributeLogicalName("createdby")]
      public EntityReference CreatedBy
      {
         get
         {
            return GetAttributeValue<EntityReference>("createdby");
         }
      }
		
      /// <summary>
      /// Дата и время создания записи.
      /// </summary>
      [AttributeLogicalName("createdon")]
      public DateTime? CreatedOn
      {
         get
         {
            return GetAttributeValue<DateTime?>("createdon");
         }
      }
		
      /// <summary>
      /// Уникальный идентификатор пользователя-представителя, создавшего запись.
      /// </summary>
      [AttributeLogicalName("createdonbehalfby")]
      public EntityReference CreatedOnBehalfBy
      {
         get
         {
            return GetAttributeValue<EntityReference>("createdonbehalfby");
         }
      }
		
      /// <summary>
      /// Порядковый номер импорта, в результате которого была создана эта запись.
      /// </summary>
      [AttributeLogicalName("importsequencenumber")]
      public int? ImportSequenceNumber
      {
         get
         {
            return GetAttributeValue<int?>("importsequencenumber");
         }
         set
         {
            OnPropertyChanging("ImportSequenceNumber");
            SetAttributeValue("importsequencenumber", value);
            OnPropertyChanged("ImportSequenceNumber");
         }
      }
		
      /// <summary>
      /// Уникальный идентификатор пользователя, изменившего запись.
      /// </summary>
      [AttributeLogicalName("modifiedby")]
      public EntityReference ModifiedBy
      {
         get
         {
            return GetAttributeValue<EntityReference>("modifiedby");
         }
      }
		
      /// <summary>
      /// Дата и время изменения записи.
      /// </summary>
      [AttributeLogicalName("modifiedon")]
      public DateTime? ModifiedOn
      {
         get
         {
            return GetAttributeValue<DateTime?>("modifiedon");
         }
      }
		
      /// <summary>
      /// Уникальный идентификатор пользователя-представителя, изменившего запись.
      /// </summary>
      [AttributeLogicalName("modifiedonbehalfby")]
      public EntityReference ModifiedOnBehalfBy
      {
         get
         {
            return GetAttributeValue<EntityReference>("modifiedonbehalfby");
         }
      }
		
      /// <summary>
      /// Показывает резервируемый ресурс.
      /// </summary>
      [AttributeLogicalName("msdyn_bookableresource")]
      public EntityReference BookableResource
      {
         get
         {
            return GetAttributeValue<EntityReference>("msdyn_bookableresource");
         }
         set
         {
            OnPropertyChanging("BookableResource");
            SetAttributeValue("msdyn_bookableresource", value);
            OnPropertyChanged("BookableResource");
         }
      }
		
      /// <summary>
      /// Уникальный идентификатор резервирования ресурса, связанного с записью времени.
      /// </summary>
      [AttributeLogicalName("msdyn_bookableresourcebooking")]
      public EntityReference BookableResourceBooking
      {
         get
         {
            return GetAttributeValue<EntityReference>("msdyn_bookableresourcebooking");
         }
         set
         {
            OnPropertyChanging("BookableResourceBooking");
            SetAttributeValue("msdyn_bookableresourcebooking", value);
            OnPropertyChanged("BookableResourceBooking");
         }
      }
		
      /// <summary>
      /// Состояние резервирования
      /// </summary>
      [AttributeLogicalName("msdyn_bookingstatus")]
      public EntityReference BookingStatus
      {
         get
         {
            return GetAttributeValue<EntityReference>("msdyn_bookingstatus");
         }
         set
         {
            OnPropertyChanging("BookingStatus");
            SetAttributeValue("msdyn_bookingstatus", value);
            OnPropertyChanged("BookingStatus");
         }
      }
		
      /// <summary>
      /// Ввод даты записи времени.
      /// </summary>
      [AttributeLogicalName("msdyn_date")]
      public DateTime? Date
      {
         get
         {
            return GetAttributeValue<DateTime?>("msdyn_date");
         }
         set
         {
            OnPropertyChanging("Date");
            SetAttributeValue("msdyn_date", value);
            OnPropertyChanged("Date");
         }
      }
		
      /// <summary>
      /// Тип описания записи времени.
      /// </summary>
      [AttributeLogicalName("msdyn_description")]
      public string Description
      {
         get
         {
            return GetAttributeValue<string>("msdyn_description");
         }
         set
         {
            OnPropertyChanging("Description");
            SetAttributeValue("msdyn_description", value);
            OnPropertyChanged("Description");
         }
      }
		
      /// <summary>
      /// Показывает потраченное время.
      /// </summary>
      [AttributeLogicalName("msdyn_duration")]
      public int? Duration
      {
         get
         {
            return GetAttributeValue<int?>("msdyn_duration");
         }
         set
         {
            OnPropertyChanging("Duration");
            SetAttributeValue("msdyn_duration", value);
            OnPropertyChanged("Duration");
         }
      }
		
      /// <summary>
      /// Время окончания записи времени.
      /// </summary>
      [AttributeLogicalName("msdyn_end")]
      public DateTime? End
      {
         get
         {
            return GetAttributeValue<DateTime?>("msdyn_end");
         }
         set
         {
            OnPropertyChanging("End");
            SetAttributeValue("msdyn_end", value);
            OnPropertyChanged("End");
         }
      }
		
      /// <summary>
      /// Выбор состояния ввода.
      /// </summary>
      [AttributeLogicalName("msdyn_entrystatus")]
      public OptionSetValue EntryStatus
      {
         get
         {
            return GetAttributeValue<OptionSetValue>("msdyn_entrystatus");
         }
         set
         {
            OnPropertyChanging("EntryStatus");
            SetAttributeValue("msdyn_entrystatus", value);
            OnPropertyChanged("EntryStatus");
         }
      }
		
      /// <summary>
      /// Тип внешнего описания записи времени.
      /// </summary>
      [AttributeLogicalName("msdyn_externaldescription")]
      public string ExternalDescription
      {
         get
         {
            return GetAttributeValue<string>("msdyn_externaldescription");
         }
         set
         {
            OnPropertyChanging("ExternalDescription");
            SetAttributeValue("msdyn_externaldescription", value);
            OnPropertyChanged("ExternalDescription");
         }
      }
		
      /// <summary>
      /// Только для внутреннего использования.
      /// </summary>
      [AttributeLogicalName("msdyn_internalflags")]
      public string InternalFlags
      {
         get
         {
            return GetAttributeValue<string>("msdyn_internalflags");
         }
         set
         {
            OnPropertyChanging("InternalFlags");
            SetAttributeValue("msdyn_internalflags", value);
            OnPropertyChanged("InternalFlags");
         }
      }
		
      /// <summary>
      /// Выберите руководителя для пользователя, делающего запись времени. Это поле используется для утверждения.
      /// </summary>
      [AttributeLogicalName("msdyn_manager")]
      public EntityReference Manager
      {
         get
         {
            return GetAttributeValue<EntityReference>("msdyn_manager");
         }
         set
         {
            OnPropertyChanging("Manager");
            SetAttributeValue("msdyn_manager", value);
            OnPropertyChanged("Manager");
         }
      }
		
      /// <summary>
      /// Выберите проект, к которому относится запись времени.
      /// </summary>
      [AttributeLogicalName("msdyn_project")]
      public EntityReference Project
      {
         get
         {
            return GetAttributeValue<EntityReference>("msdyn_project");
         }
         set
         {
            OnPropertyChanging("Project");
            SetAttributeValue("msdyn_project", value);
            OnPropertyChanged("Project");
         }
      }
		
      /// <summary>
      /// Выбор задачи проекта, к которой относится запись времени.
      /// </summary>
      [AttributeLogicalName("msdyn_projecttask")]
      public EntityReference ProjectTask
      {
         get
         {
            return GetAttributeValue<EntityReference>("msdyn_projecttask");
         }
         set
         {
            OnPropertyChanging("ProjectTask");
            SetAttributeValue("msdyn_projecttask", value);
            OnPropertyChanged("ProjectTask");
         }
      }
		
      /// <summary>
      /// Идентификатор связанного элемента.
      /// </summary>
      [AttributeLogicalName("msdyn_relateditemid")]
      public string RelatedItemId
      {
         get
         {
            return GetAttributeValue<string>("msdyn_relateditemid");
         }
         set
         {
            OnPropertyChanging("RelatedItemId");
            SetAttributeValue("msdyn_relateditemid", value);
            OnPropertyChanged("RelatedItemId");
         }
      }
		
      /// <summary>
      /// Тип связанного элемента
      /// </summary>
      [AttributeLogicalName("msdyn_relateditemtype")]
      public OptionSetValue RelatedItemType
      {
         get
         {
            return GetAttributeValue<OptionSetValue>("msdyn_relateditemtype");
         }
         set
         {
            OnPropertyChanging("RelatedItemType");
            SetAttributeValue("msdyn_relateditemtype", value);
            OnPropertyChanged("RelatedItemType");
         }
      }
		
      /// <summary>
      /// Выберите роль пользователя в проекте, для которого предназначена запись времени.
      /// </summary>
      [AttributeLogicalName("msdyn_resourcecategory")]
      public EntityReference ResourceCategory
      {
         get
         {
            return GetAttributeValue<EntityReference>("msdyn_resourcecategory");
         }
         set
         {
            OnPropertyChanging("ResourceCategory");
            SetAttributeValue("msdyn_resourcecategory", value);
            OnPropertyChanged("ResourceCategory");
         }
      }
		
      /// <summary>
      /// Выберите подразделение на момент регистрации записи для ресурса, выполнившего работу.
      /// </summary>
      [AttributeLogicalName("msdyn_resourceorganizationalunitid")]
      public EntityReference ResourceOrganizationalUnitId
      {
         get
         {
            return GetAttributeValue<EntityReference>("msdyn_resourceorganizationalunitid");
         }
         set
         {
            OnPropertyChanging("ResourceOrganizationalUnitId");
            SetAttributeValue("msdyn_resourceorganizationalunitid", value);
            OnPropertyChanged("ResourceOrganizationalUnitId");
         }
      }
		
      /// <summary>
      /// Время начала записи времени.
      /// </summary>
      [AttributeLogicalName("msdyn_start")]
      public DateTime? Start
      {
         get
         {
            return GetAttributeValue<DateTime?>("msdyn_start");
         }
         set
         {
            OnPropertyChanging("Start");
            SetAttributeValue("msdyn_start", value);
            OnPropertyChanged("Start");
         }
      }
		
      /// <summary>
      /// 
      /// </summary>
      [AttributeLogicalName("msdyn_targetentrystatus")]
      public OptionSetValue TargetEntryStatus
      {
         get
         {
            return GetAttributeValue<OptionSetValue>("msdyn_targetentrystatus");
         }
         set
         {
            OnPropertyChanging("TargetEntryStatus");
            SetAttributeValue("msdyn_targetentrystatus", value);
            OnPropertyChanged("TargetEntryStatus");
         }
      }
		
      /// <summary>
      /// Уникальный идентификатор записи времени.
      /// </summary>
      [AttributeLogicalName("msdyn_timeentryid")]
      public Guid? TimeEntryId
      {
         get
         {
            return GetAttributeValue<Guid?>("msdyn_timeentryid");
         }
         set
         {
            OnPropertyChanging("TimeEntryId");
            SetAttributeValue("msdyn_timeentryid", value);
            base.Id = value ?? Guid.Empty;
            OnPropertyChanged("TimeEntryId");
         }
      }
		
      [AttributeLogicalName("msdyn_timeentryid")]
      public override Guid Id
      {
         get
         {
            return base.Id;
         }
         set
         {
            TimeEntryId = value;
         }
      }
		
      /// <summary>
      /// Уникальный идентификатор источника времени, связанного с записью времени.
      /// </summary>
      [AttributeLogicalName("msdyn_timeentrysettingid")]
      public EntityReference TimeEntrySettingId
      {
         get
         {
            return GetAttributeValue<EntityReference>("msdyn_timeentrysettingid");
         }
         set
         {
            OnPropertyChanging("TimeEntrySettingId");
            SetAttributeValue("msdyn_timeentrysettingid", value);
            OnPropertyChanged("TimeEntrySettingId");
         }
      }
		
      /// <summary>
      /// Уникальный идентификатор для запроса выходных, связанный с записью времени. Это поле автоматически заполняется, когда запись времени создается автоматически из запроса выходных.
      /// </summary>
      [AttributeLogicalName("msdyn_timeoffrequest")]
      public EntityReference TimeOffRequest
      {
         get
         {
            return GetAttributeValue<EntityReference>("msdyn_timeoffrequest");
         }
         set
         {
            OnPropertyChanging("TimeOffRequest");
            SetAttributeValue("msdyn_timeoffrequest", value);
            OnPropertyChanged("TimeOffRequest");
         }
      }
		
      /// <summary>
      /// Показывает категорию проводки.
      /// </summary>
      [AttributeLogicalName("msdyn_transactioncategory")]
      public EntityReference TransactionCategory
      {
         get
         {
            return GetAttributeValue<EntityReference>("msdyn_transactioncategory");
         }
         set
         {
            OnPropertyChanging("TransactionCategory");
            SetAttributeValue("msdyn_transactioncategory", value);
            OnPropertyChanged("TransactionCategory");
         }
      }
		
      /// <summary>
      /// Выбор типа записи времени.
      /// </summary>
      [AttributeLogicalName("msdyn_type")]
      public OptionSetValue Type
      {
         get
         {
            return GetAttributeValue<OptionSetValue>("msdyn_type");
         }
         set
         {
            OnPropertyChanging("Type");
            SetAttributeValue("msdyn_type", value);
            OnPropertyChanged("Type");
         }
      }
		
      /// <summary>
      /// Уникальный идентификатор для заказов на работу, связанных с записью времени.
      /// </summary>
      [AttributeLogicalName("msdyn_workorder")]
      public EntityReference WorkOrder
      {
         get
         {
            return GetAttributeValue<EntityReference>("msdyn_workorder");
         }
         set
         {
            OnPropertyChanging("WorkOrder");
            SetAttributeValue("msdyn_workorder", value);
            OnPropertyChanged("WorkOrder");
         }
      }
		
      /// <summary>
      /// Дата и время переноса записи.
      /// </summary>
      [AttributeLogicalName("overriddencreatedon")]
      public DateTime? OverriddenCreatedOn
      {
         get
         {
            return GetAttributeValue<DateTime?>("overriddencreatedon");
         }
         set
         {
            OnPropertyChanging("OverriddenCreatedOn");
            SetAttributeValue("overriddencreatedon", value);
            OnPropertyChanged("OverriddenCreatedOn");
         }
      }
		
      /// <summary>
      /// ИД ответственного
      /// </summary>
      [AttributeLogicalName("ownerid")]
      public EntityReference OwnerId
      {
         get
         {
            return GetAttributeValue<EntityReference>("ownerid");
         }
         set
         {
            OnPropertyChanging("OwnerId");
            SetAttributeValue("ownerid", value);
            OnPropertyChanged("OwnerId");
         }
      }
		
      /// <summary>
      /// Уникальный идентификатор бизнес-единицы, ответственной за запись
      /// </summary>
      [AttributeLogicalName("owningbusinessunit")]
      public EntityReference OwningBusinessUnit
      {
         get
         {
            return GetAttributeValue<EntityReference>("owningbusinessunit");
         }
      }
		
      /// <summary>
      /// Уникальный идентификатор рабочей группы, ответственной за запись.
      /// </summary>
      [AttributeLogicalName("owningteam")]
      public EntityReference OwningTeam
      {
         get
         {
            return GetAttributeValue<EntityReference>("owningteam");
         }
      }
		
      /// <summary>
      /// Уникальный идентификатор пользователя, ответственного за запись.
      /// </summary>
      [AttributeLogicalName("owninguser")]
      public EntityReference OwningUser
      {
         get
         {
            return GetAttributeValue<EntityReference>("owninguser");
         }
      }
		
      /// <summary>
      /// Содержит идентификатор связанного с сущностью процесса.
      /// </summary>
      [AttributeLogicalName("processid")]
      public Guid? ProcessId
      {
         get
         {
            return GetAttributeValue<Guid?>("processid");
         }
         set
         {
            OnPropertyChanging("ProcessId");
            SetAttributeValue("processid", value);
            OnPropertyChanged("ProcessId");
         }
      }
		
      /// <summary>
      /// Содержит код стадии, в которой находится сущность.
      /// </summary>
      [AttributeLogicalName("stageid")]
      public Guid? StageId
      {
         get
         {
            return GetAttributeValue<Guid?>("stageid");
         }
         set
         {
            OnPropertyChanging("StageId");
            SetAttributeValue("stageid", value);
            OnPropertyChanged("StageId");
         }
      }
		
      /// <summary>
      /// Состояние записи времени
      /// </summary>
      [AttributeLogicalName("statecode")]
      public TimeEntryState? StateCode
      {
         get
         {
            OptionSetValue optionSet = GetAttributeValue<OptionSetValue>("statecode");
            if ((optionSet != null))
            {
               return ((TimeEntryState)(Enum.ToObject(typeof(TimeEntryState), optionSet.Value)));
            }
				
            return null;
         }
         set
         {
            OnPropertyChanging("StateCode");
            SetAttributeValue("statecode", value == null ? null : new OptionSetValue(((int) (value))));
            OnPropertyChanged("StateCode");
         }
      }
		
      /// <summary>
      /// Причина состояния записи времени
      /// </summary>
      [AttributeLogicalName("statuscode")]
      public OptionSetValue StatusCode
      {
         get
         {
            return GetAttributeValue<OptionSetValue>("statuscode");
         }
         set
         {
            OnPropertyChanging("StatusCode");
            SetAttributeValue("statuscode", value);
            OnPropertyChanged("StatusCode");
         }
      }
		
      /// <summary>
      /// Только для внутреннего использования.
      /// </summary>
      [AttributeLogicalName("timezoneruleversionnumber")]
      public int? TimeZoneRuleVersionNumber
      {
         get
         {
            return GetAttributeValue<int?>("timezoneruleversionnumber");
         }
         set
         {
            OnPropertyChanging("TimeZoneRuleVersionNumber");
            SetAttributeValue("timezoneruleversionnumber", value);
            OnPropertyChanged("TimeZoneRuleVersionNumber");
         }
      }
		
      /// <summary>
      /// Разделенный запятыми список строковых значений, представляющих уникальные идентификаторы стадий в экземпляре последовательности операций бизнес-процесса в порядке, в котором они возникают.
      /// </summary>
      [AttributeLogicalName("traversedpath")]
      public string TraversedPath
      {
         get
         {
            return GetAttributeValue<string>("traversedpath");
         }
         set
         {
            OnPropertyChanging("TraversedPath");
            SetAttributeValue("traversedpath", value);
            OnPropertyChanged("TraversedPath");
         }
      }
		
      /// <summary>
      /// Идентификатор часового пояса, использовавшийся при создании записи.
      /// </summary>
      [AttributeLogicalName("utcconversiontimezonecode")]
      public int? UtcConversionTimeZoneCode
      {
         get
         {
            return GetAttributeValue<int?>("utcconversiontimezonecode");
         }
         set
         {
            OnPropertyChanging("UtcConversionTimeZoneCode");
            SetAttributeValue("utcconversiontimezonecode", value);
            OnPropertyChanged("UtcConversionTimeZoneCode");
         }
      }
		
      /// <summary>
      /// Номер версии
      /// </summary>
      [AttributeLogicalName("versionnumber")]
      public long? VersionNumber
      {
         get
         {
            return GetAttributeValue<long?>("versionnumber");
         }
      }

      #endregion

      #region Private Methods

      private void OnPropertyChanged(string propertyName)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }

      private void OnPropertyChanging(string propertyName)
      {
         PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
      }

      #endregion
	}
}