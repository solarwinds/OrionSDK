/** @type {import('@docusaurus/types').DocusaurusConfig} */
module.exports = {
  title: 'Orion SDK',
  tagline: 'Using the SolarWinds Orion platform API',
  url: 'http://solarwinds.github.io',
  baseUrl: '/OrionSDK/',
  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',
  favicon: 'img/favicon.ico',
  organizationName: 'solarwinds', // Usually your GitHub org/user name.
  projectName: 'OrionSDK', // Usually your repo name.
  themeConfig: {
    navbar: {
      title: 'Orion SDK',
      logo: {
        alt: 'SolarWinds Logo',
        src: 'img/logo.svg',
      },
      items: [
        {
          to: 'docs/',
          activeBasePath: 'docs',
          label: 'Docs',
          position: 'left',
        },
        {to: 'blog', label: 'Blog', position: 'left'},
        {
          href: 'https://github.com/solarwinds/OrionSDK',
          label: 'GitHub',
          position: 'right',
        },
      ],
    },
    footer: {
      style: 'dark',
      links: [
        {
          title: 'Docs',
          items: [
            {
              label: 'Getting Started',
              to: 'docs/',
            },
          ],
        },
        {
          title: 'Community',
          items: [
            {
              label: 'THWACK',
              href: 'https://thwack.solarwinds.com/product-forums/the-orion-platform/f/orion-sdk',
            },
            {
              label: 'Stack Overflow',
              href: 'https://stackoverflow.com/questions/tagged/solarwinds-orion',
            },
            {
              label: 'Twitter',
              href: 'https://twitter.com/solarwinds',
            },
          ],
        },
        {
          title: 'More',
          items: [
            {
              label: 'Blog',
              to: 'blog',
            },
            {
              label: 'GitHub',
              href: 'https://github.com/solarwinds/OrionSDK',
            },
          ],
        },
      ],
      copyright: `Copyright © ${new Date().getFullYear()} SolarWinds Worldwide, LLC. All rights reserved.`,
    },
  },
  presets: [
    [
      '@docusaurus/preset-classic',
      {
        docs: {
          sidebarPath: require.resolve('./sidebars.js'),
          // Please change this to your repo.
          editUrl:
            'https://github.com/solarwinds/OrionSDK/edit/documentation/',
        },
        blog: {
          showReadingTime: true,
          // Please change this to your repo.
          editUrl:
            'https://github.com/solarwinds/OrionSDK/edit/documentation/blog/',
        },
        theme: {
          customCss: require.resolve('./src/css/custom.css'),
        },
      },
    ],
  ],
};
