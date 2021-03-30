namespace CurryOn.Fihr.Balancer.Models.Dto

open CurryOn.Serialization
open System

[<Struct; CLIMutable>]
type HttpRoute =
    {
        Id: string
        Context: string
        Template: string
        Segments: string []
    } 

[<Struct; CLIMutable>]
type ClientTarget = { ClientId: string }

[<Struct; CLIMutable>]
type UserTarget = { UserId: string }

[<OneOf>]
type RuleTarget =
| Global
| AnyClient
| AnyUser
| SpecificClient of ClientTarget
| SpecificUser of UserTarget

[<Struct; CLIMutable>]
type RateLimit =
    {
        MaxRequests: int64
        TimeSpan: TimeSpan
    }

[<Struct; CLIMutable>]
type ConcurrentCallsLimit =
    {
        MaxConcurrentCalls: int64
    }

[<OneOf>]
type RuleDefinition =
| RateLimiting of RateLimit
| ConcurrencyLimiting of ConcurrentCallsLimit

[<Struct; CLIMutable>]
type DropRequestEnforcement = { StatusCode: int }

[<Struct; CLIMutable>]
type QueueRequestEnforcement = { ReevaulateRulesOnDequeue: bool }

[<Struct; CLIMutable>]
type DelayRequestEnforcement = { DelayTime: TimeSpan; ReevaulateRulesAfterDelay: bool }

[<OneOf>]
type RuleEnforcement =
| Drop of DropRequestEnforcement
| Queue of QueueRequestEnforcement
| Delay of DelayRequestEnforcement

[<CLIMutable>]
type EndpointRule =
    {
        Id: string
        Target: RuleTarget
        Definition: RuleDefinition
        Enforcement: RuleEnforcement
    }

[<CLIMutable>]
type HttpEndpoint =
    {
        Id: string
        Context: string
        Version: string
        Type: string
        BaseUri: string
        Rules: EndpointRule []
    }

[<Struct; CLIMutable>]
type HttpRouteMapping =
    {
        RouteId: string
        EndpointId: string
    } 