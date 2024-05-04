module MiniCrawler

open System.Net.Http
open System.Text.RegularExpressions
open System.Threading

let downloadPageAsync (url: string, httpClient: HttpClient) =
    async {
        let httpRequest = new HttpRequestMessage(HttpMethod.Get, url) 
        let! response = httpClient.SendAsync(httpRequest, CancellationToken.None) |> Async.AwaitTask
        let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
        return content
    }

let extractLinks (html: string) : string[] =
    let pattern = "<a\\s+(?:[^>]*?\\s+)?href=\"(https://[^\"]*)\""
    Regex.Matches(html, pattern)
    |> Seq.cast<Match>
    |> Seq.map (_.Groups.[1].Value)
    |> Seq.toArray

let getPageSizes (url: string, httpClient: HttpClient) =
    async {
        let! html = downloadPageAsync (url, httpClient)
        let links = extractLinks html
        let tasks = links |> Array.map (fun link -> async {
            let! content = downloadPageAsync (link, httpClient)
            return link, content.Length
        })
        let! results = Async.Parallel tasks
        return results
    }

let printPageSizes (url: string, httpClient: HttpClient) =
    Async.RunSynchronously(getPageSizes (url, httpClient)) |> Array.iter (fun (link, length) ->
        printfn $"%s{link} — %d{length}")