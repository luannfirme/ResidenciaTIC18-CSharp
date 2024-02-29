function addAuthorizationHeader() {
    const token = localStorage.getItem("authToken");

    if (token) 
        fetch.defaults.headers.set("Authorization", `Bearer ${token}`);

}

addAuthorizationHeader();