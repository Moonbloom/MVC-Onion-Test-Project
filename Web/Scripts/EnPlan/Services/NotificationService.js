function NotificationService(selectorToAppendTo) {
    'use strict';

    var queue = [],
        timeoutTime = function () {
            if (queue.length) {
                return 1000;
            } else {
                return 3000;
            }
        },
        animationSpeed = 200,
        animIn = function (selector, callback) {
            selector.hide().slideToggle(animationSpeed, callback);
        },
        animOut = function (selector, callback) {
            selector.slideToggle(animationSpeed, callback);
        };

    var generate = function (type, message, autoFade) {
        autoFade = typeof autoFade !== 'undefined' ? autoFade : true;
        var existing = $(".notification");

        if (existing.length && type != "alert") {
            queue.push({
                type: type,
                message: message,
                autoFade: autoFade
            });
        } else {
            var wrapper = $("<div />").css({
                position: "fixed",
                bottom: 0,
                left: 0,
                width: "100%",
                "z-index": (type == "alert" ? "9999" : "1000"),
                "margin": 0,
                "text-align": "center"
            }).addClass("alert-box").addClass(type).data("alert", true).addClass("notification"),
                timeout = null;

            var text = $("<span />").text(message);
            var close = $("<a />").attr("href", "#").addClass("close").html("&times;");

            close.on("click", function () {

                clearTimeout(timeout);

                animOut(wrapper, function () {

                    wrapper.remove();

                    if (queue.length) {

                        var next = queue.pop();

                        generate(next.type, next.message, next.autoFade);
                    }
                });
            });

            wrapper.append(text).append(close);

            selectorToAppendTo.append(wrapper);
            var timeoutTimeCalculated = timeoutTime();

            animIn(wrapper, function () {
                if (autoFade) {
                    timeout = setTimeout(function () {

                        animOut(wrapper, function () {


                            wrapper.remove();

                            if (queue.length) {

                                var next = queue.pop();

                                generate(next.type, next.message, next.autoFade);
                            }
                        });
                    }, timeoutTimeCalculated);
                } else {
                    if (queue.length) {
                        var next = queue.pop();

                        generate(next.type, next.message, next.autoFade);
                    }
                }
            });
        }
    };

    var error = function (message, autoFade) {
        generate("alert", message, autoFade);
    },

    warning = function (message, autoFade) {
        generate("warning", message, autoFade);
    },

    info = function (message, autoFade) {
        generate("info", message, autoFade);
    },

    success = function (message, autoFade) {
        generate("success", message, autoFade);
    },

    runQueue = function () {
        if (queue.length) {
            var notification = queue.pop();

            generate(notification.type, notification.message, notification.autoFade);
        }
    };

    return {
        error: error,
        warning: warning,
        info: info,
        success: success,
        runQueue: runQueue
    };
}