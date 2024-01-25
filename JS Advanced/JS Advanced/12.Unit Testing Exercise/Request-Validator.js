function validate(request) {
    const httpMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const httpVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    if (request.method === undefined || !httpMethods.includes(request.method)) {
        throw new Error('Invalid request header: Invalid Method')
    }

    if (request.uri === undefined || !request.uri.match(/^([a-zA-Z0-9\.]+|\*)$/g)) {
        throw new Error('Invalid request header: Invalid URI');
    }

    if (request.version === undefined || !httpVersions.includes(request.version)) {
        throw new Error('Invalid request header: Invalid Version')
    }

    if(request.message === undefined || !request.message.match((/^[^<>&\'\"\\]*$/g))){
        throw new Error('Invalid request header: Invalid Message')
    }

    return request;
}

console.log(validate({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: '',
}));

console.log(validate({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
   }));