Sentry.init({
        dsn: "https://d84018cdc2bb4879a7d6b23d29fed5f5@sentry.rayvarz.cloud/7",
        tracesSampleRate: 1.0,
        integrations: [new Sentry.Integrations.BrowserTracing()],
     })