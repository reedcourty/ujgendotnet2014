﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PomodoroGUI.PomodoroServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tag", Namespace="http://schemas.datacontract.org/2004/07/PomodoroDAL")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PomodoroGUI.PomodoroServiceReference.PomodoroTag))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PomodoroGUI.PomodoroServiceReference.ProjectTag))]
    public partial class Tag : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PomodoroGUI.PomodoroServiceReference.Entry[] EntriesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TagNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PomodoroGUI.PomodoroServiceReference.Entry[] Entries {
            get {
                return this.EntriesField;
            }
            set {
                if ((object.ReferenceEquals(this.EntriesField, value) != true)) {
                    this.EntriesField = value;
                    this.RaisePropertyChanged("Entries");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TagName {
            get {
                return this.TagNameField;
            }
            set {
                if ((object.ReferenceEquals(this.TagNameField, value) != true)) {
                    this.TagNameField = value;
                    this.RaisePropertyChanged("TagName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PomodoroTag", Namespace="http://schemas.datacontract.org/2004/07/PomodoroDAL")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PomodoroGUI.PomodoroServiceReference.ProjectTag))]
    public partial class PomodoroTag : PomodoroGUI.PomodoroServiceReference.Tag {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreatedAtField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreatedAt {
            get {
                return this.CreatedAtField;
            }
            set {
                if ((this.CreatedAtField.Equals(value) != true)) {
                    this.CreatedAtField = value;
                    this.RaisePropertyChanged("CreatedAt");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProjectTag", Namespace="http://schemas.datacontract.org/2004/07/PomodoroDAL")]
    [System.SerializableAttribute()]
    public partial class ProjectTag : PomodoroGUI.PomodoroServiceReference.PomodoroTag {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PriorityField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Priority {
            get {
                return this.PriorityField;
            }
            set {
                if ((this.PriorityField.Equals(value) != true)) {
                    this.PriorityField = value;
                    this.RaisePropertyChanged("Priority");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Entry", Namespace="http://schemas.datacontract.org/2004/07/PomodoroDAL")]
    [System.SerializableAttribute()]
    public partial class Entry : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PomodoroGUI.PomodoroServiceReference.Comment CommentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PomodoroGUI.PomodoroServiceReference.Tag[] TagsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimestampField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PomodoroGUI.PomodoroServiceReference.Comment Comment {
            get {
                return this.CommentField;
            }
            set {
                if ((object.ReferenceEquals(this.CommentField, value) != true)) {
                    this.CommentField = value;
                    this.RaisePropertyChanged("Comment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PomodoroGUI.PomodoroServiceReference.Tag[] Tags {
            get {
                return this.TagsField;
            }
            set {
                if ((object.ReferenceEquals(this.TagsField, value) != true)) {
                    this.TagsField = value;
                    this.RaisePropertyChanged("Tags");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Timestamp {
            get {
                return this.TimestampField;
            }
            set {
                if ((this.TimestampField.Equals(value) != true)) {
                    this.TimestampField = value;
                    this.RaisePropertyChanged("Timestamp");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Comment", Namespace="http://schemas.datacontract.org/2004/07/PomodoroDAL")]
    [System.SerializableAttribute()]
    public partial class Comment : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CommentIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PomodoroGUI.PomodoroServiceReference.Entry EntryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EntryIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CommentId {
            get {
                return this.CommentIdField;
            }
            set {
                if ((this.CommentIdField.Equals(value) != true)) {
                    this.CommentIdField = value;
                    this.RaisePropertyChanged("CommentId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PomodoroGUI.PomodoroServiceReference.Entry Entry {
            get {
                return this.EntryField;
            }
            set {
                if ((object.ReferenceEquals(this.EntryField, value) != true)) {
                    this.EntryField = value;
                    this.RaisePropertyChanged("Entry");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EntryId {
            get {
                return this.EntryIdField;
            }
            set {
                if ((this.EntryIdField.Equals(value) != true)) {
                    this.EntryIdField = value;
                    this.RaisePropertyChanged("EntryId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PomodoroServiceReference.IPomodoroService")]
    public interface IPomodoroService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPomodoroService/AddTag", ReplyAction="http://tempuri.org/IPomodoroService/AddTagResponse")]
        PomodoroGUI.PomodoroServiceReference.Tag AddTag(string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPomodoroService/AddTag", ReplyAction="http://tempuri.org/IPomodoroService/AddTagResponse")]
        System.Threading.Tasks.Task<PomodoroGUI.PomodoroServiceReference.Tag> AddTagAsync(string tagName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPomodoroService/UpdateEntry", ReplyAction="http://tempuri.org/IPomodoroService/UpdateEntryResponse")]
        string UpdateEntry(int entryId, string oldDescription, string newDescription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPomodoroService/UpdateEntry", ReplyAction="http://tempuri.org/IPomodoroService/UpdateEntryResponse")]
        System.Threading.Tasks.Task<string> UpdateEntryAsync(int entryId, string oldDescription, string newDescription);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPomodoroService/SaveEntry", ReplyAction="http://tempuri.org/IPomodoroService/SaveEntryResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IPomodoroService/SaveEntryFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        void SaveEntry(System.DateTime timestamp, string description, string tags);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPomodoroService/SaveEntry", ReplyAction="http://tempuri.org/IPomodoroService/SaveEntryResponse")]
        System.Threading.Tasks.Task SaveEntryAsync(System.DateTime timestamp, string description, string tags);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPomodoroService/GetEntries", ReplyAction="http://tempuri.org/IPomodoroService/GetEntriesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(System.ServiceModel.FaultException), Action="http://tempuri.org/IPomodoroService/GetEntriesFaultExceptionFault", Name="FaultException", Namespace="http://schemas.datacontract.org/2004/07/System.ServiceModel")]
        PomodoroGUI.PomodoroServiceReference.Entry[] GetEntries();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPomodoroService/GetEntries", ReplyAction="http://tempuri.org/IPomodoroService/GetEntriesResponse")]
        System.Threading.Tasks.Task<PomodoroGUI.PomodoroServiceReference.Entry[]> GetEntriesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPomodoroServiceChannel : PomodoroGUI.PomodoroServiceReference.IPomodoroService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PomodoroServiceClient : System.ServiceModel.ClientBase<PomodoroGUI.PomodoroServiceReference.IPomodoroService>, PomodoroGUI.PomodoroServiceReference.IPomodoroService {
        
        public PomodoroServiceClient() {
        }
        
        public PomodoroServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PomodoroServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PomodoroServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PomodoroServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PomodoroGUI.PomodoroServiceReference.Tag AddTag(string tagName) {
            return base.Channel.AddTag(tagName);
        }
        
        public System.Threading.Tasks.Task<PomodoroGUI.PomodoroServiceReference.Tag> AddTagAsync(string tagName) {
            return base.Channel.AddTagAsync(tagName);
        }
        
        public string UpdateEntry(int entryId, string oldDescription, string newDescription) {
            return base.Channel.UpdateEntry(entryId, oldDescription, newDescription);
        }
        
        public System.Threading.Tasks.Task<string> UpdateEntryAsync(int entryId, string oldDescription, string newDescription) {
            return base.Channel.UpdateEntryAsync(entryId, oldDescription, newDescription);
        }
        
        public void SaveEntry(System.DateTime timestamp, string description, string tags) {
            base.Channel.SaveEntry(timestamp, description, tags);
        }
        
        public System.Threading.Tasks.Task SaveEntryAsync(System.DateTime timestamp, string description, string tags) {
            return base.Channel.SaveEntryAsync(timestamp, description, tags);
        }
        
        public PomodoroGUI.PomodoroServiceReference.Entry[] GetEntries() {
            return base.Channel.GetEntries();
        }
        
        public System.Threading.Tasks.Task<PomodoroGUI.PomodoroServiceReference.Entry[]> GetEntriesAsync() {
            return base.Channel.GetEntriesAsync();
        }
    }
}
