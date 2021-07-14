Sentry.init({
    environment: "Testing",
    dsn: document.cookie.substr(11),
    tracesSampleRate: 1.0,
    integrations: [new Sentry.Integrations.BrowserTracing()],
    sampleRate: 1.0,
});
