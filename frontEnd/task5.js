const task4 = require('./task4');

const path = require('path');
const fs = require('fs');

function ensureDirectoryExistence() {
    if (!fs.existsSync("Characters")) {
        fs.mkdirSync("Characters", { recursive: true })
    } else {
        console.log('Folder already exists')
    }
}

(async () => {
    const items = await task4.getCharacters()
    console.log(items?.data?.results);
    ensureDirectoryExistence();
    (items?.data?.results || []).forEach(element => {
        console.log(element)

        fs.writeFile(`Characters//${element?.id}.json`, JSON.stringify(element), function (err) {
            if (err) {
                console.log(err);
            }
        });
    });
})();
