const path = require('path')
const JSZip = require('jszip')
const {
  red,
  green,
  blue,
  yellow,
  writeFileAsync,
  createDirIfNotExists,
  httpGet,
} = require('./utils')

const logProgress = msg => console.log(yellow(msg))

const destinationDir = () => path.join(__dirname, './google-icons')
const robotsDestination = () => path.join(destinationDir(), 'robots.txt')
const iconsJsonDestination = () =>
  path.join(destinationDir(), 'material-icons.json')
const assetsDir = () => path.join(destinationDir(), 'assets')
const iconCategoryDir = category => path.join(assetsDir(), category)
const iconDensityDestination = (category, density) =>
  path.join(iconCategoryDir(category), density)
const iconFamilyDestination = (category, density, family) =>
  path.join(
    iconDensityDestination(category, density),
    family.replace(/ /gi, '-').toLowerCase(),
  )
const iconAssetDestination = (category, density, family, asset) =>
  path.join(iconFamilyDestination(category, density, family), asset)

const iconsJsonUrl = () => 'https://fonts.google.com/metadata/icons'
const iconAssetUrl = (host, pattern, family, version, name, asset) =>
  `https://${host}${pattern
    .replace('{family}', family.replace(/ /gi, '').toLowerCase())
    .replace('{icon}', name)
    .replace('{version}', version)
    .replace('{asset}', asset)}`

const ICON_ASSET_DENSITY_1X_WEB = '1x_web'
const ICON_ASSET_DENSITY_2X_WEB = '2x_web'
const ICON_ASSET_DENSITY_DRAWABLE = 'drawable'
const ICON_ASSET_DENSITY_DRAWABLE_HDPI = 'drawable-hdpi'
const ICON_ASSET_DENSITY_DRAWABLE_MDPI = 'drawable-mdpi'
const ICON_ASSET_DENSITY_DRAWABLE_XHDPI = 'drawable-xhdpi'
const ICON_ASSET_DENSITY_DRAWABLE_XXHDPI = 'drawable-xxhdpi'
const ICON_ASSET_DENSITY_DRAWABLE_XXXHDPI = 'drawable-xxxhdpi'
const ICON_ASSET_DENSITY_IOS = 'ios'
const ICON_ASSET_DENSITY_SVG = 'svg'

const iconFamilyToZipAssetPrefix = family => {
  switch (family) {
    case 'Material Icons':
      return 'baseline'
    case 'Material Icons Outlined':
      return 'outline'
    case 'Material Icons Round':
      return 'round'
    case 'Material Icons Sharp':
      return 'sharp'
    case 'Material Icons Two Tone':
      return 'twotone'
    default:
      throw new Error(`Unknown family: ${family}`)
  }
}

const zipAssetFileName = (family, name, asset) =>
  `${iconFamilyToZipAssetPrefix(family)}_${name}_${asset}`

const downloadIconsJson = async () => {
  const buffer = await httpGet(iconsJsonUrl())
  const json = JSON.parse(buffer.toString('utf8').replace(")]}'", ''))

  return json
}

const iconCategories = iconsJson =>
  iconsJson.icons
    .map(ic => ic.categories)
    .reduce((arr, cats) => arr.concat(cats), [])
    .filter((cat, i, arr) => arr.indexOf(cat) === i)

const createIconCategoryDirs = categories =>
  Promise.all(
    categories.map(category => createDirIfNotExists(iconCategoryDir(category))),
  )

const createIconDensityDirs = categories =>
  Promise.all(
    categories
      .reduce(
        (all, category) =>
          all.concat([
            iconDensityDestination(category, ICON_ASSET_DENSITY_1X_WEB),
            iconDensityDestination(category, ICON_ASSET_DENSITY_2X_WEB),
            iconDensityDestination(category, ICON_ASSET_DENSITY_DRAWABLE),
            iconDensityDestination(category, ICON_ASSET_DENSITY_DRAWABLE_HDPI),
            iconDensityDestination(category, ICON_ASSET_DENSITY_DRAWABLE_MDPI),
            iconDensityDestination(category, ICON_ASSET_DENSITY_DRAWABLE_XHDPI),
            iconDensityDestination(
              category,
              ICON_ASSET_DENSITY_DRAWABLE_XXHDPI,
            ),
            iconDensityDestination(
              category,
              ICON_ASSET_DENSITY_DRAWABLE_XXXHDPI,
            ),
            iconDensityDestination(category, ICON_ASSET_DENSITY_IOS),
            iconDensityDestination(category, ICON_ASSET_DENSITY_SVG),
          ]),
        [],
      )
      .map(dir => createDirIfNotExists(dir)),
  )

const createIconFamilyDirs = (categories, families) =>
  Promise.all(
    categories
      .reduce(
        (all, category) =>
          all.concat([
            ...families.map(family =>
              iconFamilyDestination(
                category,
                ICON_ASSET_DENSITY_1X_WEB,
                family,
              ),
            ),
            ...families.map(family =>
              iconFamilyDestination(
                category,
                ICON_ASSET_DENSITY_2X_WEB,
                family,
              ),
            ),
            ...families.map(family =>
              iconFamilyDestination(
                category,
                ICON_ASSET_DENSITY_DRAWABLE,
                family,
              ),
            ),
            ...families.map(family =>
              iconFamilyDestination(
                category,
                ICON_ASSET_DENSITY_DRAWABLE_HDPI,
                family,
              ),
            ),
            ...families.map(family =>
              iconFamilyDestination(
                category,
                ICON_ASSET_DENSITY_DRAWABLE_MDPI,
                family,
              ),
            ),
            ...families.map(family =>
              iconFamilyDestination(
                category,
                ICON_ASSET_DENSITY_DRAWABLE_XHDPI,
                family,
              ),
            ),
            ...families.map(family =>
              iconFamilyDestination(
                category,
                ICON_ASSET_DENSITY_DRAWABLE_XXHDPI,
                family,
              ),
            ),
            ...families.map(family =>
              iconFamilyDestination(
                category,
                ICON_ASSET_DENSITY_DRAWABLE_XXXHDPI,
                family,
              ),
            ),
            ...families.map(family =>
              iconFamilyDestination(category, ICON_ASSET_DENSITY_IOS, family),
            ),
            ...families.map(family =>
              iconFamilyDestination(category, ICON_ASSET_DENSITY_SVG, family),
            ),
          ]),
        [],
      )
      .map(dir => createDirIfNotExists(dir)),
  )

const flattenIconsJson = async iconsJson => {
  const { icons } = iconsJson
  const categories = iconCategories({ icons })
  const json = {
    categories: categories.map(category => ({
      id: category,
      name: category,
      icons: icons
        .filter(icon => icon.categories.includes(category))
        .map(icon => ({
          id: icon.name,
          name: icon.name,
          keywords: icon.tags,
        })),
    })),
  }

  await writeFileAsync(iconsJsonDestination(), JSON.stringify(json, null, 0))
}

const createRobotsTxt = () =>
  writeFileAsync(robotsDestination(), 'User-agent: *\nDisallow: /')

const downloadDPIcon = async (
  host,
  assetUrlPattern,
  families,
  dpSize,
  icon,
) => {
  for (const family of families) {
    const { name, version, categories } = icon
    const zipBuffer = await httpGet(
      iconAssetUrl(
        host,
        assetUrlPattern,
        family,
        version,
        name,
        `black-${dpSize}.zip`,
      ),
    )

    const zip = new JSZip()
    await zip.loadAsync(zipBuffer)

    const asset1X = await zip
      .folder('1x')
      .file(zipAssetFileName(family, name, `black_${dpSize}.png`))
      .async('nodebuffer')
    await Promise.all(
      categories.map(category =>
        writeFileAsync(
          iconAssetDestination(
            category,
            ICON_ASSET_DENSITY_1X_WEB,
            family,
            `${name}_${dpSize}.png`,
          ),
          asset1X,
        ),
      ),
    )

    const asset2X = await zip
      .folder('2x')
      .file(zipAssetFileName(family, name, `black_${dpSize}.png`))
      .async('nodebuffer')
    await Promise.all(
      categories.map(category =>
        writeFileAsync(
          iconAssetDestination(
            category,
            ICON_ASSET_DENSITY_2X_WEB,
            family,
            `${name}_${dpSize}.png`,
          ),
          asset2X,
        ),
      ),
    )
  }
}

const downloadIOSIcon = async (host, assetUrlPattern, families, icon) => {
  for (const family of families) {
    const { name, version, categories } = icon
    const zipBuffer = await httpGet(
      iconAssetUrl(
        host,
        assetUrlPattern,
        family,
        version,
        name,
        `black-ios.zip`,
      ),
    )

    const zip = new JSZip()
    await zip.loadAsync(zipBuffer)

    for (const size of ['18pt', '24pt', '36pt', '48pt']) {
      for (const density of ['1x', '2x', '3x']) {
        const asset = await zip
          .folder(zipAssetFileName(family, name, `black_${size}.xcassets`))
          .folder(zipAssetFileName(family, name, `black_${size}.imageset`))
          .file(zipAssetFileName(family, name, `black_${size}_${density}.png`))
          .async('nodebuffer')
        await Promise.all(
          categories.map(category =>
            writeFileAsync(
              iconAssetDestination(
                category,
                ICON_ASSET_DENSITY_IOS,
                family,
                `${name}_${size}_${density}.png`,
              ),
              asset,
            ),
          ),
        )
      }
    }
  }
}

const downloadAndroidIcon = async (host, assetUrlPattern, families, icon) => {
  for (const family of families) {
    const { name, version, categories } = icon
    const zipBuffer = await httpGet(
      iconAssetUrl(
        host,
        assetUrlPattern,
        family,
        version,
        name,
        `black-android.zip`,
      ),
    )

    const zip = new JSZip()
    await zip.loadAsync(zipBuffer)

    for (const size of ['18', '24', '36', '48']) {
      for (const density of [
        ICON_ASSET_DENSITY_DRAWABLE,
        ICON_ASSET_DENSITY_DRAWABLE_MDPI,
        ICON_ASSET_DENSITY_DRAWABLE_HDPI,
        ICON_ASSET_DENSITY_DRAWABLE_XHDPI,
        ICON_ASSET_DENSITY_DRAWABLE_XXHDPI,
        ICON_ASSET_DENSITY_DRAWABLE_XXXHDPI,
      ]) {
        if (density === ICON_ASSET_DENSITY_DRAWABLE && size !== '24') {
          continue
        }

        const assetName =
          density === ICON_ASSET_DENSITY_DRAWABLE
            ? `${size}.xml`
            : `black_${size}.png`
        const asset = await zip
          .folder('res')
          .folder(density)
          .file(zipAssetFileName(family, name, assetName))
          .async('nodebuffer')
        await Promise.all(
          categories.map(category =>
            writeFileAsync(
              iconAssetDestination(
                category,
                density,
                family,
                `${name}_${size}dp.${
                  density === ICON_ASSET_DENSITY_DRAWABLE ? 'xml' : 'png'
                }`,
              ),
              asset,
            ),
          ),
        )
      }
    }
  }
}

const downloadSVGIcon = async (host, assetUrlPattern, families, icon) => {
  for (const family of families) {
    const { name, version, categories } = icon
    const svgBuffer = await httpGet(
      iconAssetUrl(
        host,
        assetUrlPattern,
        family,
        version,
        name,
        '24px.svg?download=true',
      ),
    )

    await Promise.all(
      categories.map(category =>
        writeFileAsync(
          iconAssetDestination(
            category,
            ICON_ASSET_DENSITY_SVG,
            family,
            `${name}.svg`,
          ),
          svgBuffer,
        ),
      ),
    )
  }
}

const collect = async () => {
  logProgress('Stating ....')

  const iconsJson = await downloadIconsJson()
  logProgress('Icons json downloaded')

  await createDirIfNotExists(destinationDir())
  logProgress('Icons dir created')
  await createDirIfNotExists(assetsDir())
  logProgress('Assets dir created')

  await flattenIconsJson(iconsJson)
  logProgress('Icons json saved')
  await createRobotsTxt()
  logProgress('robots.txt file saved')

  const { host, asset_url_pattern, families, icons } = iconsJson

  const categories = iconCategories(iconsJson)
  await createIconCategoryDirs(categories)
  logProgress('Icon category dirs created')
  await createIconDensityDirs(categories)
  logProgress('Icon category density dirs created')
  await createIconFamilyDirs(categories, families)
  logProgress('Icon category family dirs created')

  logProgress(`Starting to download ${icons.length} icons ...`)
  for (const [index, icon] of icons.entries()) {
    logProgress(`Downloading #${index} ${blue(icon.name)} 18dp ...`)
    await downloadDPIcon(host, asset_url_pattern, families, '18dp', icon)
    logProgress(`Downloading #${index} ${blue(icon.name)} 24dp ...`)
    await downloadDPIcon(host, asset_url_pattern, families, '24dp', icon)
    logProgress(`Downloading #${index} ${blue(icon.name)} 36dp ...`)
    await downloadDPIcon(host, asset_url_pattern, families, '36dp', icon)
    logProgress(`Downloading #${index} ${blue(icon.name)} 48dp ...`)
    await downloadDPIcon(host, asset_url_pattern, families, '48dp', icon)
    logProgress(`Downloading #${index} ${blue(icon.name)} ios ...`)
    await downloadIOSIcon(host, asset_url_pattern, families, icon)
    logProgress(`Downloading #${index} ${blue(icon.name)} android ...`)
    await downloadAndroidIcon(host, asset_url_pattern, families, icon)
    logProgress(`Downloading #${index} ${blue(icon.name)} svg ...`)
    await downloadSVGIcon(host, asset_url_pattern, families, icon)
  }
}

if (require.main === module) {
  collect()
    .then(() => {
      console.log(green('finished ...'))
      process.exit(0)
    })
    .catch(err => {
      console.log(red(err.message))
      console.log(red(err.stack))
      process.exit(1)
    })
}
