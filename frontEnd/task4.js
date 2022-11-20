const axios = require('axios');
const MD5 = require("crypto-js/md5");

(async () => {
    const ts = 1
    const privateKey = "7d6034385bc0edc60fc393253d9e530f6a1e1473"
    const publicKey = "5ee61daa430178f84ad7d87483b28839"
    const hash = MD5(ts + privateKey + publicKey).toString()
    const { data } = await axios.get(`http://gateway.marvel.com/v1/public/characters?apikey=${publicKey}&hash=${hash}&ts=${ts}`);
    console.log(data);
})();