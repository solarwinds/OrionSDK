window.onload = function() {
  //<editor-fold desc="Changeable Configuration Block">

  function getPrimaryName(name) {
    const params = new URLSearchParams(window.location.search);
    return params.get(name) || 'Unknown';
  }

  const primaryName = getPrimaryName('urls.primaryName');

  // the following lines will be replaced by docker/configurator, when it runs in a docker-container
  window.ui = SwaggerUIBundle({
    urls: [
      {url:"https://solarwinds.github.io/OrionSDK/2026.1/swagger.json", name:"2026.1"},
      {url:"https://solarwinds.github.io/OrionSDK/2025.4/swagger.json", name:"2025.4"},
      {url:"https://solarwinds.github.io/OrionSDK/2025.2.1/swagger.json", name:"2025.2.1"},
      {url:"https://solarwinds.github.io/OrionSDK/2025.2/swagger.json", name:"2025.2"},
      {url:"https://solarwinds.github.io/OrionSDK/2025.1.1/swagger.json", name:"2025.1.1"},
      {url:"https://solarwinds.github.io/OrionSDK/2025.1/swagger.json", name:"2025.1"},
      {url:"https://solarwinds.github.io/OrionSDK/2024.4.1/swagger.json", name:"2024.4.1"},
      {url:"https://solarwinds.github.io/OrionSDK/2024.4/swagger.json", name:"2024.4"},
      {url:"https://solarwinds.github.io/OrionSDK/2024.2/swagger.json", name:"2024.2"},
      {url:"https://solarwinds.github.io/OrionSDK/2024.1/swagger.json", name:"2024.1"},
      {url:"https://solarwinds.github.io/OrionSDK/2023.4/swagger.json", name:"2023.4"},
      {url:"https://solarwinds.github.io/OrionSDK/2023.3/swagger.json", name:"2023.3"},
      {url:"https://solarwinds.github.io/OrionSDK/2023.2/swagger.json", name:"2023.2"},
      {url:"https://solarwinds.github.io/OrionSDK/2023.1/swagger.json", name:"2023.1"}
    ],
    "urls.primaryName": primaryName || "2025.2.1",
    dom_id: '#swagger-ui',
    deepLinking: true,
    presets: [
      SwaggerUIBundle.presets.apis,
      SwaggerUIStandalonePreset
    ],
    plugins: [
      SwaggerUIBundle.plugins.DownloadUrl
    ],
    layout: "StandaloneLayout",
    supportedSubmitMethods: []
  });

  //</editor-fold>
};
