module WebScraperTests

open System.Threading
open NUnit.Framework
open System.Net.Http
open Moq
open System.Net
open FsUnit
open MiniCrawler

[<Test>]
let Test (): unit =
    let mockHttpClient = Mock<HttpClient>()
    let exampleUrl = "https://example.com/"

    let response = new HttpResponseMessage(HttpStatusCode.OK)

    let linkResponse = new HttpResponseMessage(HttpStatusCode.OK)
    linkResponse.Content <- new StringContent("Example content")

    mockHttpClient
        .Setup(fun client -> client.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>()))
        .ReturnsAsync(response)
        .Callback(fun (req: HttpRequestMessage) (ct: CancellationToken) -> 
            if (req).RequestUri.AbsoluteUri = exampleUrl then
                response.Content <- new StringContent("Example content")
            else
                response.Content <- new StringContent($"<html><body><a href=\"{exampleUrl}\">Example</a></body></html>")) |> ignore

    let expected = [| (exampleUrl, 15) |]
    let actual = Async.RunSynchronously (getPageSizes ("https://fakeurl.com", mockHttpClient.Object))
    
    Assert.AreEqual(expected, actual)