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
    dsn: "https://7ceb6f89b1a54369af4de126849da0ee@sentry.rayvarz.dev/2",
    tracesSampleRate: 1.0,
    integrations: [new Sentry.Integrations.BrowserTracing()],
    sampleRate: 1.0,
});
//    initialScope: {
//        tags: {"Client": "ClientRequests88"},
//        user: {id: 1, email: "rfinland88@gmail.com"},
//        transaction() {
//            const transaction = Sentry.startTransaction({ name: "transaction" });
//            Sentry.getCurrentHub().configureScope(scope => scope.setSpan(transaction));
//            const result = POW();

//            const span = transaction.startChild({
//                data: {
//                    result
//                },
//                op: 'task',
//                description: 'Client requests',
//            });
//            POW(result);
//            span.finish();

//            transaction.finish();
//        }    
//    },
    // this assumes your build process sets "npm_package_version" in the env
    // release: "my-project-name@" + process.env.npm_package_version,
    // integrations: [new MyAwesomeIntegration()],
      //    Capturing a single trace involves minimal overhead, but capturing traces for every page load or every API request may add an undesirable load to your system.
    // Enabling sampling allows you to better manage the number of events sent to Sentry, so you can tailor your volume to your organization's needs.
    // We recommend adjusting this value in production, or using tracesSampler for finer control https://docs.sentry.io/platforms/javascript/configuration/sampling/
    // maxBreadcrumbs: 50, //This variable controls the total amount of breadcrumbs that should be captured. This defaults to 100
    // debug: true, //not recommended to turn it on in production 
    //Other options are listed :https://docs.sentry.io/platforms/javascript/configuration/options/

    // beforeSend(event) {
    //     if (event.user) {
    //         // Don't send user's email address
    //         delete event.user.email;
    //     }
    //     return event;
    // },   // For more:https://docs.sentry.io/platforms/javascript/configuration/filtering/

// Sentry.setTag("rrweb.active", hasReplays ? "yes" : "no");
