namespace CurryOn.Fihr.Balancer.Models.Dto

[<Struct; CLIMutable>]
type HttpClient =
    {
        Id: string
        Address: string
        UserName: string
    } 

[<Struct; CLIMutable>]
type HttpHeader =
    {
        Name: string
        Values: string []
    }

[<CLIMutable>]
type BalancedHttpRequest =
    {
        RequestId: string
        Headers: HttpHeader []
        Method: string
        Body: byte []
        Client: HttpClient        
        OriginUrl: string
        OriginServer: string
        DestinationUrl: string
        DestinationServer: string
    } 