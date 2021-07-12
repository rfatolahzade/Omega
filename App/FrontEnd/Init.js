// const hasReplays = getCurrentUser().isStaff;
//
// let integrationsT = [];
// if (hasReplays) {
//     console.log("[sentry] Instrumenting session with rrweb");
//     integrationsT.push(new SentryRRWeb());
// }
Sentry.init({
    // integrationsT,
    environment: "Testing",
    dsn: "https://d84018cdc2bb4879a7d6b23d29fed5f5@sentry.rayvarz.cloud/7",
    // this assumes your build process sets "npm_package_version" in the env
    // release: "my-project-name@" + process.env.npm_package_version,
    integrations: [new Sentry.Integrations.BrowserTracing()],
    // integrations: [new MyAwesomeIntegration()],
    sampleRate: 1.0,  //    Capturing a single trace involves minimal overhead, but capturing traces for every page load or every API request may add an undesirable load to your system.
    // Enabling sampling allows you to better manage the number of events sent to Sentry, so you can tailor your volume to your organization's needs.
    // We recommend adjusting this value in production, or using tracesSampler for finer control https://docs.sentry.io/platforms/javascript/configuration/sampling/
    tracesSampleRate: 1.0,
    // maxBreadcrumbs: 50, //This variable controls the total amount of breadcrumbs that should be captured. This defaults to 100
    // debug: true, //not recommended to turn it on in production 
    //Other options are listed :https://docs.sentry.io/platforms/javascript/configuration/options/
    initialScope: {
        tags: {"Client": "ClientRequests88"},
        user: {id: 1, email: "rfinland88@gmail.com"},
    },
    // beforeSend(event) {
    //     if (event.user) {
    //         // Don't send user's email address
    //         delete event.user.email;
    //     }
    //     return event;
    // },   // For more:https://docs.sentry.io/platforms/javascript/configuration/filtering/
});
// Sentry.setTag("rrweb.active", hasReplays ? "yes" : "no");