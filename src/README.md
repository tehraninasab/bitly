# Url Shortener


## Development

### Data base requirements

'''bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add Bitly.UrlDbContext
dotnet ef database update
'''

## Running the tests

### You should use a json file that contains unit tests. like:
 
'''
{
    "ValidData" : [ 
        ["https://a.valid.url]
    ]

    "InvalidData" : [
        ["aninvalidurl"]
    ]

}
'''

### For post method tests or

'''
[
     ["shortEndpoint", "longUrl"], 
]
'''

### For redirect tests


## Client side requests
'''
    ### GET /redirect/{shortEndpoint}
    ''' Redirect to actual url '''
    ## WHEN: Trying invalid request

    ### Response: 404 Not Found


    ### POST /bitly 

    ### Response: 200 OK
    '''json
    { 
        shortUrl : foo,
        longUrl : bar
    }
    '''


    #### Headers
    * Content-Type: application/json;charset=utf-8

    #### Body
    ```json
    {"foo": "bar"}
    ```
    ## WHEN: Trying invalid url

    ### Response: 400 Bad Request

    #### Headers

    * Content-Type: text/plain;charset=utf-8
'''

## Build With

* [ASP.Net](https://docs.microsoft.com/en-us/dotnet/) - The web framework used
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) - The Programming language

