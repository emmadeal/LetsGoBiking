﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RootingService.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Station", Namespace="http://schemas.datacontract.org/2004/07/Proxy")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(RootingService.ServiceReference1.MainStands))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(RootingService.ServiceReference1.Avaibilities))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(RootingService.ServiceReference1.Position))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(RootingService.ServiceReference1.TotalStands))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(RootingService.ServiceReference1.Contract[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(RootingService.ServiceReference1.Contract))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(RootingService.ServiceReference1.Station[]))]
    public partial class Station : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BankingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BonusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ConnectedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContractNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime LastUpdateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RootingService.ServiceReference1.MainStands MainStandsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool OverflowField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object OverflowStandsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RootingService.ServiceReference1.Position PositionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ShapeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RootingService.ServiceReference1.TotalStands TotalStandsField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Banking {
            get {
                return this.BankingField;
            }
            set {
                if ((this.BankingField.Equals(value) != true)) {
                    this.BankingField = value;
                    this.RaisePropertyChanged("Banking");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Bonus {
            get {
                return this.BonusField;
            }
            set {
                if ((this.BonusField.Equals(value) != true)) {
                    this.BonusField = value;
                    this.RaisePropertyChanged("Bonus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Connected {
            get {
                return this.ConnectedField;
            }
            set {
                if ((this.ConnectedField.Equals(value) != true)) {
                    this.ConnectedField = value;
                    this.RaisePropertyChanged("Connected");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ContractName {
            get {
                return this.ContractNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ContractNameField, value) != true)) {
                    this.ContractNameField = value;
                    this.RaisePropertyChanged("ContractName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime LastUpdate {
            get {
                return this.LastUpdateField;
            }
            set {
                if ((this.LastUpdateField.Equals(value) != true)) {
                    this.LastUpdateField = value;
                    this.RaisePropertyChanged("LastUpdate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RootingService.ServiceReference1.MainStands MainStands {
            get {
                return this.MainStandsField;
            }
            set {
                if ((object.ReferenceEquals(this.MainStandsField, value) != true)) {
                    this.MainStandsField = value;
                    this.RaisePropertyChanged("MainStands");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Number {
            get {
                return this.NumberField;
            }
            set {
                if ((this.NumberField.Equals(value) != true)) {
                    this.NumberField = value;
                    this.RaisePropertyChanged("Number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Overflow {
            get {
                return this.OverflowField;
            }
            set {
                if ((this.OverflowField.Equals(value) != true)) {
                    this.OverflowField = value;
                    this.RaisePropertyChanged("Overflow");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object OverflowStands {
            get {
                return this.OverflowStandsField;
            }
            set {
                if ((object.ReferenceEquals(this.OverflowStandsField, value) != true)) {
                    this.OverflowStandsField = value;
                    this.RaisePropertyChanged("OverflowStands");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RootingService.ServiceReference1.Position Position {
            get {
                return this.PositionField;
            }
            set {
                if ((object.ReferenceEquals(this.PositionField, value) != true)) {
                    this.PositionField = value;
                    this.RaisePropertyChanged("Position");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Shape {
            get {
                return this.ShapeField;
            }
            set {
                if ((object.ReferenceEquals(this.ShapeField, value) != true)) {
                    this.ShapeField = value;
                    this.RaisePropertyChanged("Shape");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status {
            get {
                return this.StatusField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusField, value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RootingService.ServiceReference1.TotalStands TotalStands {
            get {
                return this.TotalStandsField;
            }
            set {
                if ((object.ReferenceEquals(this.TotalStandsField, value) != true)) {
                    this.TotalStandsField = value;
                    this.RaisePropertyChanged("TotalStands");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="MainStands", Namespace="http://schemas.datacontract.org/2004/07/Proxy")]
    [System.SerializableAttribute()]
    public partial class MainStands : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RootingService.ServiceReference1.Avaibilities availabilitiesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int capacityField;
        
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
        public RootingService.ServiceReference1.Avaibilities availabilities {
            get {
                return this.availabilitiesField;
            }
            set {
                if ((object.ReferenceEquals(this.availabilitiesField, value) != true)) {
                    this.availabilitiesField = value;
                    this.RaisePropertyChanged("availabilities");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int capacity {
            get {
                return this.capacityField;
            }
            set {
                if ((this.capacityField.Equals(value) != true)) {
                    this.capacityField = value;
                    this.RaisePropertyChanged("capacity");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Position", Namespace="http://schemas.datacontract.org/2004/07/Proxy")]
    [System.SerializableAttribute()]
    public partial class Position : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LattitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double LongitudeField;
        
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
        public double Lattitude {
            get {
                return this.LattitudeField;
            }
            set {
                if ((this.LattitudeField.Equals(value) != true)) {
                    this.LattitudeField = value;
                    this.RaisePropertyChanged("Lattitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Longitude {
            get {
                return this.LongitudeField;
            }
            set {
                if ((this.LongitudeField.Equals(value) != true)) {
                    this.LongitudeField = value;
                    this.RaisePropertyChanged("Longitude");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TotalStands", Namespace="http://schemas.datacontract.org/2004/07/Proxy")]
    [System.SerializableAttribute()]
    public partial class TotalStands : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RootingService.ServiceReference1.Avaibilities AvaibilitiesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CapacityField;
        
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
        public RootingService.ServiceReference1.Avaibilities Avaibilities {
            get {
                return this.AvaibilitiesField;
            }
            set {
                if ((object.ReferenceEquals(this.AvaibilitiesField, value) != true)) {
                    this.AvaibilitiesField = value;
                    this.RaisePropertyChanged("Avaibilities");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Capacity {
            get {
                return this.CapacityField;
            }
            set {
                if ((this.CapacityField.Equals(value) != true)) {
                    this.CapacityField = value;
                    this.RaisePropertyChanged("Capacity");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Avaibilities", Namespace="http://schemas.datacontract.org/2004/07/Proxy")]
    [System.SerializableAttribute()]
    public partial class Avaibilities : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ElectricalBikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ElectricalInternalBatteryBikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ElectricalRemovableBatteryBikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MechanicalBikesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StandsField;
        
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
        public int Bikes {
            get {
                return this.BikesField;
            }
            set {
                if ((this.BikesField.Equals(value) != true)) {
                    this.BikesField = value;
                    this.RaisePropertyChanged("Bikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ElectricalBikes {
            get {
                return this.ElectricalBikesField;
            }
            set {
                if ((this.ElectricalBikesField.Equals(value) != true)) {
                    this.ElectricalBikesField = value;
                    this.RaisePropertyChanged("ElectricalBikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ElectricalInternalBatteryBikes {
            get {
                return this.ElectricalInternalBatteryBikesField;
            }
            set {
                if ((this.ElectricalInternalBatteryBikesField.Equals(value) != true)) {
                    this.ElectricalInternalBatteryBikesField = value;
                    this.RaisePropertyChanged("ElectricalInternalBatteryBikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ElectricalRemovableBatteryBikes {
            get {
                return this.ElectricalRemovableBatteryBikesField;
            }
            set {
                if ((this.ElectricalRemovableBatteryBikesField.Equals(value) != true)) {
                    this.ElectricalRemovableBatteryBikesField = value;
                    this.RaisePropertyChanged("ElectricalRemovableBatteryBikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MechanicalBikes {
            get {
                return this.MechanicalBikesField;
            }
            set {
                if ((this.MechanicalBikesField.Equals(value) != true)) {
                    this.MechanicalBikesField = value;
                    this.RaisePropertyChanged("MechanicalBikes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Stands {
            get {
                return this.StandsField;
            }
            set {
                if ((this.StandsField.Equals(value) != true)) {
                    this.StandsField = value;
                    this.RaisePropertyChanged("Stands");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Contract", Namespace="http://schemas.datacontract.org/2004/07/Proxy")]
    [System.SerializableAttribute()]
    public partial class Contract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetStationInfo", ReplyAction="http://tempuri.org/IService1/GetStationInfoResponse")]
        RootingService.ServiceReference1.Station GetStationInfo(string contractName, string stationNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetStationInfo", ReplyAction="http://tempuri.org/IService1/GetStationInfoResponse")]
        System.Threading.Tasks.Task<RootingService.ServiceReference1.Station> GetStationInfoAsync(string contractName, string stationNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetListContract", ReplyAction="http://tempuri.org/IService1/GetListContractResponse")]
        RootingService.ServiceReference1.Contract[] GetListContract();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetListContract", ReplyAction="http://tempuri.org/IService1/GetListContractResponse")]
        System.Threading.Tasks.Task<RootingService.ServiceReference1.Contract[]> GetListContractAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetListStation", ReplyAction="http://tempuri.org/IService1/GetListStationResponse")]
        RootingService.ServiceReference1.Station[] GetListStation(string contractName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetListStation", ReplyAction="http://tempuri.org/IService1/GetListStationResponse")]
        System.Threading.Tasks.Task<RootingService.ServiceReference1.Station[]> GetListStationAsync(string contractName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetStations", ReplyAction="http://tempuri.org/IService1/GetStationsResponse")]
        RootingService.ServiceReference1.Station[] GetStations();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetStations", ReplyAction="http://tempuri.org/IService1/GetStationsResponse")]
        System.Threading.Tasks.Task<RootingService.ServiceReference1.Station[]> GetStationsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : RootingService.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<RootingService.ServiceReference1.IService1>, RootingService.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public RootingService.ServiceReference1.Station GetStationInfo(string contractName, string stationNumber) {
            return base.Channel.GetStationInfo(contractName, stationNumber);
        }
        
        public System.Threading.Tasks.Task<RootingService.ServiceReference1.Station> GetStationInfoAsync(string contractName, string stationNumber) {
            return base.Channel.GetStationInfoAsync(contractName, stationNumber);
        }
        
        public RootingService.ServiceReference1.Contract[] GetListContract() {
            return base.Channel.GetListContract();
        }
        
        public System.Threading.Tasks.Task<RootingService.ServiceReference1.Contract[]> GetListContractAsync() {
            return base.Channel.GetListContractAsync();
        }
        
        public RootingService.ServiceReference1.Station[] GetListStation(string contractName) {
            return base.Channel.GetListStation(contractName);
        }
        
        public System.Threading.Tasks.Task<RootingService.ServiceReference1.Station[]> GetListStationAsync(string contractName) {
            return base.Channel.GetListStationAsync(contractName);
        }
        
        public RootingService.ServiceReference1.Station[] GetStations() {
            return base.Channel.GetStations();
        }
        
        public System.Threading.Tasks.Task<RootingService.ServiceReference1.Station[]> GetStationsAsync() {
            return base.Channel.GetStationsAsync();
        }
    }
}
