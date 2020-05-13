const util = require('util')
const https = require('https')
const fs = require('fs')

const red = msg => `\x1b[31m${msg}\x1b[0m`
const green = msg => `\x1b[32m${msg}\x1b[0m`
const blue = msg => `\x1b[34m${msg}\x1b[0m`
const yellow = msg => `\x1b[33m${msg}\x1b[0m`

const writeFileAsync = util.promisify(fs.writeFile)
const mkdirAsync = util.promisify(fs.mkdir)
const existsAsync = util.promisify(fs.exists)

const createDirIfNotExists = async name =>
  (await existsAsync(name)) ? Promise.resolve() : mkdirAsync(name)

const httpGet = url =>
  new Promise((resolve, reject) => {
    https
      .get(url, response => {
        if (response.statusCode !== 200) {
          return reject(
            new Error(
              `Request Failed. ` +
                `Status Code: ${response.statusCode}. ` +
                `Status Message: ${response.statusMessage}`,
            ),
          )
        }

        const chunks = []
        response.on('data', chunk => chunks.push(chunk))
        response.on('end', () => resolve(Buffer.concat(chunks)))
      })
      .on('error', err => reject(err))
  })

module.exports = {
  red,
  green,
  blue,
  yellow,
  existsAsync,
  writeFileAsync,
  mkdirAsync,
  createDirIfNotExists,
  httpGet,
}
