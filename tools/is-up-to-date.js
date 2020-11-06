const { green, red, yellow, httpGet } = require('./utils')
const { downloadIconsJson } = require('./collect-google-icons')

const downloadPluginIconsJson = () =>
  httpGet(
    'https://www.vs-material-icons-generator.com/icon-providers/google/material-icons.json',
  ).then(JSON.parse)

const countPluginIcons = json =>
  json.categories.reduce((acc, category) => acc + category.icons.length, 0)

if (require.main === module) {
  Promise.all([downloadPluginIconsJson(), downloadIconsJson()])
    .then(results => [countPluginIcons(results[0]), results[1].icons.length])
    .then(([pluginCount, googleCount]) => {
      if (pluginCount === googleCount) {
        console.log(green(`Plugin icons is up to date ${pluginCount}.`))
        process.exit(0)
      } else {
        console.log(
          red(
            `Plugin icons is out of date, plugin: ${pluginCount} google: ${googleCount}.`,
          ),
        )
        process.exit(1)
      }
    })
    .catch(err => {
      console.log(yellow(err.message))
      console.log(yellow(err.stack))
      process.exit(1)
    })
}
