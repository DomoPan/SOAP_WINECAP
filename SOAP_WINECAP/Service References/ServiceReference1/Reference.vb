﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Il codice è stato generato da uno strumento.
'     Versione runtime:4.0.30319.34011
'
'     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
'     il codice viene rigenerato.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace ServiceReference1
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="urn:winecapws", ConfigurationName:="ServiceReference1.winecapwsPort")>  _
    Public Interface winecapwsPort
        
        <System.ServiceModel.OperationContractAttribute(Action:="urn:winecapwsAction", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(Style:=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults:=true, Use:=System.ServiceModel.OperationFormatUse.Encoded),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(daydeg)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(history)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(sensor)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(measure))>  _
        Function getCurrentValues(ByVal wsLicense As String, ByVal wliMac As String) As <System.ServiceModel.MessageParameterAttribute(Name:="result")> ServiceReference1.measure()
        
        <System.ServiceModel.OperationContractAttribute(Action:="urn:winecapwsAction", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(Style:=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults:=true, Use:=System.ServiceModel.OperationFormatUse.Encoded),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(daydeg)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(history)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(sensor)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(measure))>  _
        Function getSensorList(ByVal wsLicense As String, ByVal wliMac As String) As <System.ServiceModel.MessageParameterAttribute(Name:="result")> ServiceReference1.sensor()
        
        <System.ServiceModel.OperationContractAttribute(Action:="urn:winecapwsAction", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(Style:=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults:=true, Use:=System.ServiceModel.OperationFormatUse.Encoded),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(daydeg)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(history)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(sensor)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(measure))>  _
        Function getChannelHistory(ByVal wsLicense As String, ByVal wliMac As String, ByVal sensorMac As String, ByVal sensorCh As Integer, ByVal dateFrom As Long, ByVal dateTo As Long) As <System.ServiceModel.MessageParameterAttribute(Name:="result")> ServiceReference1.history()
        
        <System.ServiceModel.OperationContractAttribute(Action:="urn:winecapwsAction", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(Style:=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults:=true, Use:=System.ServiceModel.OperationFormatUse.Encoded),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(daydeg)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(history)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(sensor)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(measure))>  _
        Function getTotDeg(ByVal wsLicense As String, ByVal wliMac As String, ByVal sensorMac As String, ByVal dateFrom As Long, ByVal dateTo As Long, ByVal realRif As Single) As <System.ServiceModel.MessageParameterAttribute(Name:="result")> ServiceReference1.totdeg
        
        <System.ServiceModel.OperationContractAttribute(Action:="urn:winecapwsAction", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(Style:=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults:=true, Use:=System.ServiceModel.OperationFormatUse.Encoded),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(daydeg)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(history)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(sensor)),  _
         System.ServiceModel.ServiceKnownTypeAttribute(GetType(measure))>  _
        Function getDayDeg(ByVal wsLicense As String, ByVal wliMac As String, ByVal sensorMac As String, ByVal dateFrom As Long, ByVal dateTo As Long, ByVal realRif As Single) As <System.ServiceModel.MessageParameterAttribute(Name:="result")> ServiceReference1.daydeg()
    End Interface
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.SoapTypeAttribute([Namespace]:="urn:winecapws")>  _
    Partial Public Class measure
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private sensorNameField As String
        
        Private sensorMacField As String
        
        Private channelField As Integer
        
        Private channelTypeField As Integer
        
        Private timeStampField As Long
        
        Private valueField As Single
        
        Private invalidField As Integer
        
        Private alarmField As Integer
        
        '''<remarks/>
        Public Property sensorName() As String
            Get
                Return Me.sensorNameField
            End Get
            Set
                Me.sensorNameField = value
                Me.RaisePropertyChanged("sensorName")
            End Set
        End Property
        
        '''<remarks/>
        Public Property sensorMac() As String
            Get
                Return Me.sensorMacField
            End Get
            Set
                Me.sensorMacField = value
                Me.RaisePropertyChanged("sensorMac")
            End Set
        End Property
        
        '''<remarks/>
        Public Property channel() As Integer
            Get
                Return Me.channelField
            End Get
            Set
                Me.channelField = value
                Me.RaisePropertyChanged("channel")
            End Set
        End Property
        
        '''<remarks/>
        Public Property channelType() As Integer
            Get
                Return Me.channelTypeField
            End Get
            Set
                Me.channelTypeField = value
                Me.RaisePropertyChanged("channelType")
            End Set
        End Property
        
        '''<remarks/>
        Public Property timeStamp() As Long
            Get
                Return Me.timeStampField
            End Get
            Set
                Me.timeStampField = value
                Me.RaisePropertyChanged("timeStamp")
            End Set
        End Property
        
        '''<remarks/>
        Public Property value() As Single
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = value
                Me.RaisePropertyChanged("value")
            End Set
        End Property
        
        '''<remarks/>
        Public Property invalid() As Integer
            Get
                Return Me.invalidField
            End Get
            Set
                Me.invalidField = value
                Me.RaisePropertyChanged("invalid")
            End Set
        End Property
        
        '''<remarks/>
        Public Property alarm() As Integer
            Get
                Return Me.alarmField
            End Get
            Set
                Me.alarmField = value
                Me.RaisePropertyChanged("alarm")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.SoapTypeAttribute([Namespace]:="urn:winecapws")>  _
    Partial Public Class daydeg
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private timestampField As Long
        
        Private validField As Boolean
        
        Private tAveField As Single
        
        Private gg412Field As Single
        
        Private ggRealField As Single
        
        '''<remarks/>
        Public Property timestamp() As Long
            Get
                Return Me.timestampField
            End Get
            Set
                Me.timestampField = value
                Me.RaisePropertyChanged("timestamp")
            End Set
        End Property
        
        '''<remarks/>
        Public Property valid() As Boolean
            Get
                Return Me.validField
            End Get
            Set
                Me.validField = value
                Me.RaisePropertyChanged("valid")
            End Set
        End Property
        
        '''<remarks/>
        Public Property tAve() As Single
            Get
                Return Me.tAveField
            End Get
            Set
                Me.tAveField = value
                Me.RaisePropertyChanged("tAve")
            End Set
        End Property
        
        '''<remarks/>
        Public Property gg412() As Single
            Get
                Return Me.gg412Field
            End Get
            Set
                Me.gg412Field = value
                Me.RaisePropertyChanged("gg412")
            End Set
        End Property
        
        '''<remarks/>
        Public Property ggReal() As Single
            Get
                Return Me.ggRealField
            End Get
            Set
                Me.ggRealField = value
                Me.RaisePropertyChanged("ggReal")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.SoapTypeAttribute([Namespace]:="urn:winecapws")>  _
    Partial Public Class totdeg
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private gg412Field As Single
        
        Private ggRealField As Single
        
        Private dayTotField As Integer
        
        Private dayValidField As Integer
        
        '''<remarks/>
        Public Property gg412() As Single
            Get
                Return Me.gg412Field
            End Get
            Set
                Me.gg412Field = value
                Me.RaisePropertyChanged("gg412")
            End Set
        End Property
        
        '''<remarks/>
        Public Property ggReal() As Single
            Get
                Return Me.ggRealField
            End Get
            Set
                Me.ggRealField = value
                Me.RaisePropertyChanged("ggReal")
            End Set
        End Property
        
        '''<remarks/>
        Public Property dayTot() As Integer
            Get
                Return Me.dayTotField
            End Get
            Set
                Me.dayTotField = value
                Me.RaisePropertyChanged("dayTot")
            End Set
        End Property
        
        '''<remarks/>
        Public Property dayValid() As Integer
            Get
                Return Me.dayValidField
            End Get
            Set
                Me.dayValidField = value
                Me.RaisePropertyChanged("dayValid")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.SoapTypeAttribute([Namespace]:="urn:winecapws")>  _
    Partial Public Class history
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private timeStampField As Long
        
        Private valueField As Single
        
        Private invalidField As Integer
        
        Private alarmField As Integer
        
        '''<remarks/>
        Public Property timeStamp() As Long
            Get
                Return Me.timeStampField
            End Get
            Set
                Me.timeStampField = value
                Me.RaisePropertyChanged("timeStamp")
            End Set
        End Property
        
        '''<remarks/>
        Public Property value() As Single
            Get
                Return Me.valueField
            End Get
            Set
                Me.valueField = value
                Me.RaisePropertyChanged("value")
            End Set
        End Property
        
        '''<remarks/>
        Public Property invalid() As Integer
            Get
                Return Me.invalidField
            End Get
            Set
                Me.invalidField = value
                Me.RaisePropertyChanged("invalid")
            End Set
        End Property
        
        '''<remarks/>
        Public Property alarm() As Integer
            Get
                Return Me.alarmField
            End Get
            Set
                Me.alarmField = value
                Me.RaisePropertyChanged("alarm")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.SoapTypeAttribute([Namespace]:="urn:winecapws")>  _
    Partial Public Class sensor
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private sensorNameField As String
        
        Private sensorMacField As String
        
        Private lastConnectionField As Long
        
        Private rfTXField As Integer
        
        Private rfRXField As Integer
        
        Private batteryField As Integer
        
        '''<remarks/>
        Public Property sensorName() As String
            Get
                Return Me.sensorNameField
            End Get
            Set
                Me.sensorNameField = value
                Me.RaisePropertyChanged("sensorName")
            End Set
        End Property
        
        '''<remarks/>
        Public Property sensorMac() As String
            Get
                Return Me.sensorMacField
            End Get
            Set
                Me.sensorMacField = value
                Me.RaisePropertyChanged("sensorMac")
            End Set
        End Property
        
        '''<remarks/>
        Public Property lastConnection() As Long
            Get
                Return Me.lastConnectionField
            End Get
            Set
                Me.lastConnectionField = value
                Me.RaisePropertyChanged("lastConnection")
            End Set
        End Property
        
        '''<remarks/>
        Public Property rfTX() As Integer
            Get
                Return Me.rfTXField
            End Get
            Set
                Me.rfTXField = value
                Me.RaisePropertyChanged("rfTX")
            End Set
        End Property
        
        '''<remarks/>
        Public Property rfRX() As Integer
            Get
                Return Me.rfRXField
            End Get
            Set
                Me.rfRXField = value
                Me.RaisePropertyChanged("rfRX")
            End Set
        End Property
        
        '''<remarks/>
        Public Property battery() As Integer
            Get
                Return Me.batteryField
            End Get
            Set
                Me.batteryField = value
                Me.RaisePropertyChanged("battery")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface winecapwsPortChannel
        Inherits ServiceReference1.winecapwsPort, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class winecapwsPortClient
        Inherits System.ServiceModel.ClientBase(Of ServiceReference1.winecapwsPort)
        Implements ServiceReference1.winecapwsPort
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function getCurrentValues(ByVal wsLicense As String, ByVal wliMac As String) As ServiceReference1.measure() Implements ServiceReference1.winecapwsPort.getCurrentValues
            Return MyBase.Channel.getCurrentValues(wsLicense, wliMac)
        End Function
        
        Public Function getSensorList(ByVal wsLicense As String, ByVal wliMac As String) As ServiceReference1.sensor() Implements ServiceReference1.winecapwsPort.getSensorList
            Return MyBase.Channel.getSensorList(wsLicense, wliMac)
        End Function
        
        Public Function getChannelHistory(ByVal wsLicense As String, ByVal wliMac As String, ByVal sensorMac As String, ByVal sensorCh As Integer, ByVal dateFrom As Long, ByVal dateTo As Long) As ServiceReference1.history() Implements ServiceReference1.winecapwsPort.getChannelHistory
            Return MyBase.Channel.getChannelHistory(wsLicense, wliMac, sensorMac, sensorCh, dateFrom, dateTo)
        End Function
        
        Public Function getTotDeg(ByVal wsLicense As String, ByVal wliMac As String, ByVal sensorMac As String, ByVal dateFrom As Long, ByVal dateTo As Long, ByVal realRif As Single) As ServiceReference1.totdeg Implements ServiceReference1.winecapwsPort.getTotDeg
            Return MyBase.Channel.getTotDeg(wsLicense, wliMac, sensorMac, dateFrom, dateTo, realRif)
        End Function
        
        Public Function getDayDeg(ByVal wsLicense As String, ByVal wliMac As String, ByVal sensorMac As String, ByVal dateFrom As Long, ByVal dateTo As Long, ByVal realRif As Single) As ServiceReference1.daydeg() Implements ServiceReference1.winecapwsPort.getDayDeg
            Return MyBase.Channel.getDayDeg(wsLicense, wliMac, sensorMac, dateFrom, dateTo, realRif)
        End Function
    End Class
End Namespace
