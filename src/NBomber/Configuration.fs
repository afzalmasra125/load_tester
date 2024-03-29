﻿namespace rec NBomber.Configuration

open System
open Serilog.Events
open FSharp.Json

type ReportFormat = 
    | Txt = 0
    | Html = 1
    | Csv = 2
    | Md = 3

type LogSettings = {
    FileName: string
    MinimumLevel: LogEventLevel
}

type ScenarioSetting = {
    ScenarioName: string
    ConcurrentCopies: int
    WarmUpDuration: DateTime
    Duration: DateTime
}

type GlobalSettings = {    
    ScenariosSettings: ScenarioSetting list
    TargetScenarios: string list option
    ReportFileName: string option
    ReportFormats: ReportFormat list option
}

type AgentSettings = {
    ClusterId: string
    TargetGroup: string
    MqttServer: string
    MqttPort: int option
}

type TargetGroupSettings = {
    TargetGroup: string
    TargetScenarios: string list
}

type CoordinatorSettings = {
    ClusterId: string
    TargetScenarios: string list
    MqttServer: string
    MqttPort: int option
    Agents: TargetGroupSettings list
}

type ClusterSettings =
    | Coordinator of CoordinatorSettings
    | Agent       of AgentSettings

type NBomberConfig = {
    GlobalSettings: GlobalSettings option    
    ClusterSettings: ClusterSettings option
    LogSettings: LogSettings option
    [<JsonField(Transform=typeof<NBomberConfig.JsonStringTransform>)>]
    CustomSettings: string option
}

module internal NBomberConfig =

    type JsonStringTransform() =
        interface ITypeTransform with
            member x.targetType () = typeof<obj>
            member x.toTargetType(value) = value
            member x.fromTargetType(value) =
                let config = JsonConfig.create(allowUntyped = true)
                let str = Json.serializeEx config value
                str :> obj
    
    let parse (json) = 
        Json.deserialize<NBomberConfig>(json)