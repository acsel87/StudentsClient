﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Student_UI.StudentService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseModelOfstring", Namespace="http://schemas.datacontract.org/2004/07/Student.Models")]
    [System.SerializableAttribute()]
    public partial class ResponseModelOfstring : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSuccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ModelField;
        
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
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSuccess {
            get {
                return this.IsSuccessField;
            }
            set {
                if ((this.IsSuccessField.Equals(value) != true)) {
                    this.IsSuccessField = value;
                    this.RaisePropertyChanged("IsSuccess");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Model {
            get {
                return this.ModelField;
            }
            set {
                if ((object.ReferenceEquals(this.ModelField, value) != true)) {
                    this.ModelField = value;
                    this.RaisePropertyChanged("Model");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseModelOfUserModelB45gH_Pky", Namespace="http://schemas.datacontract.org/2004/07/Student.Models")]
    [System.SerializableAttribute()]
    public partial class ResponseModelOfUserModelB45gH_Pky : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSuccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Student_UI.StudentService.UserModel ModelField;
        
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
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSuccess {
            get {
                return this.IsSuccessField;
            }
            set {
                if ((this.IsSuccessField.Equals(value) != true)) {
                    this.IsSuccessField = value;
                    this.RaisePropertyChanged("IsSuccess");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Student_UI.StudentService.UserModel Model {
            get {
                return this.ModelField;
            }
            set {
                if ((object.ReferenceEquals(this.ModelField, value) != true)) {
                    this.ModelField = value;
                    this.RaisePropertyChanged("Model");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="UserModel", Namespace="http://schemas.datacontract.org/2004/07/Student.Models")]
    [System.SerializableAttribute()]
    public partial class UserModel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AccessTokenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
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
        public string AccessToken {
            get {
                return this.AccessTokenField;
            }
            set {
                if ((object.ReferenceEquals(this.AccessTokenField, value) != true)) {
                    this.AccessTokenField = value;
                    this.RaisePropertyChanged("AccessToken");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StudentService.IStudentService")]
    public interface IStudentService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentService/CheckConnection", ReplyAction="http://tempuri.org/IStudentService/CheckConnectionResponse")]
        string CheckConnection();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentService/CheckConnection", ReplyAction="http://tempuri.org/IStudentService/CheckConnectionResponse")]
        System.Threading.Tasks.Task<string> CheckConnectionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentService/SignUp", ReplyAction="http://tempuri.org/IStudentService/SignUpResponse")]
        Student_UI.StudentService.ResponseModelOfstring SignUp(string username, string password, string accountType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentService/SignUp", ReplyAction="http://tempuri.org/IStudentService/SignUpResponse")]
        System.Threading.Tasks.Task<Student_UI.StudentService.ResponseModelOfstring> SignUpAsync(string username, string password, string accountType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentService/Login", ReplyAction="http://tempuri.org/IStudentService/LoginResponse")]
        Student_UI.StudentService.ResponseModelOfUserModelB45gH_Pky Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentService/Login", ReplyAction="http://tempuri.org/IStudentService/LoginResponse")]
        System.Threading.Tasks.Task<Student_UI.StudentService.ResponseModelOfUserModelB45gH_Pky> LoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentService/ResetPassword", ReplyAction="http://tempuri.org/IStudentService/ResetPasswordResponse")]
        string ResetPassword();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStudentService/ResetPassword", ReplyAction="http://tempuri.org/IStudentService/ResetPasswordResponse")]
        System.Threading.Tasks.Task<string> ResetPasswordAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStudentServiceChannel : Student_UI.StudentService.IStudentService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StudentServiceClient : System.ServiceModel.ClientBase<Student_UI.StudentService.IStudentService>, Student_UI.StudentService.IStudentService {
        
        public StudentServiceClient() {
        }
        
        public StudentServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StudentServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StudentServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StudentServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string CheckConnection() {
            return base.Channel.CheckConnection();
        }
        
        public System.Threading.Tasks.Task<string> CheckConnectionAsync() {
            return base.Channel.CheckConnectionAsync();
        }
        
        public Student_UI.StudentService.ResponseModelOfstring SignUp(string username, string password, string accountType) {
            return base.Channel.SignUp(username, password, accountType);
        }
        
        public System.Threading.Tasks.Task<Student_UI.StudentService.ResponseModelOfstring> SignUpAsync(string username, string password, string accountType) {
            return base.Channel.SignUpAsync(username, password, accountType);
        }
        
        public Student_UI.StudentService.ResponseModelOfUserModelB45gH_Pky Login(string username, string password) {
            return base.Channel.Login(username, password);
        }
        
        public System.Threading.Tasks.Task<Student_UI.StudentService.ResponseModelOfUserModelB45gH_Pky> LoginAsync(string username, string password) {
            return base.Channel.LoginAsync(username, password);
        }
        
        public string ResetPassword() {
            return base.Channel.ResetPassword();
        }
        
        public System.Threading.Tasks.Task<string> ResetPasswordAsync() {
            return base.Channel.ResetPasswordAsync();
        }
    }
}