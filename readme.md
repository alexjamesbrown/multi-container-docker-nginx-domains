We want to be able to spin up multiple asp.net core containers - 'listening' on different domains for local testing.

For example https://app1.local and https://app2.local

I'm using [jwilder/nginx-proxy](https://hub.docker.com/r/jwilder/nginx-proxy/) to provide a proxy.  

This allows us to specify a `VIRTUAL_HOST` environment variable, and automatically be mapped in the nginx container.

## Getting started

**Add this to hosts file**  
127.0.0.1  app1.local  
127.0.0.1  app2.local  

**Install mkcert**  
https://github.com/FiloSottile/mkcert

Once installed, install the CA cert. Run this on cmd line:  
`mkcert -install` 

Now, run 
`docker-compose up`

Now, both urls should work:
- `https://app1.local` 
- `https://app2.local` 
