/*global ko */
function AjaxService(notify) {
    'use strict';

    var baseUrl = "/";

    return {
        buildUrl: function (bonus) {
            console.log(baseUrl + bonus);
            return baseUrl + bonus;
        },
        call: function (options) {
            // If options object exists use it, else use an empty object literal.
            var opt = options || {};
            //opt.progressUpload = function (e) { console.log(options); console.log(e); };

            //opt.auth = opt.auth || true; // Auth flag, custom thingy, not used...

            opt.type = opt.type || "POST"; // Choose type, defaults to POST
            opt.dataType = opt.dataType || "json"; // dateType, defaults to json
            opt.processData = opt.processData || false; // processData, defaults to false
            //opt.crossDomain = opt.crossDomain || true; // crossDomain, defaults to true

            /*opt.beforeSend = function(xhr){
                xhr.withCredentials = true;
            };*/

            // Makes sure we can send json in our POST request body
            if (opt.data && opt.type !== 'GET') {
                opt.contentType = 'application/json; charset=utf-8';
                //opt.data = JSON.stringify(opt.data);
                opt.data = ko.toJSON(opt.data);
                //console.log(opt.data);
            }

            // Return the ajax call with the options
            return $.ajax(opt).fail(function (xhr, textstatus) {
                notify.error("Der opstod en fejl, ved hentning af data.", false);
                //console.log(xhr);
                //console.log(xhr.status);
                //console.log(xhr.statusText);
                //console.log(xhr.responseText);
            }).done(function (data, textStatus, jqXHR) {
                if (data.Success === false) {
                    if (!data.Errors.length) {
                        notify.error("Der opstod en fejl, ved hentning af data.", false);
                        //console.log(opt.url);
                        //console.log(jqXHR);
                    } else {
                        notify.error(data.Errors[0], false);
                    }

                    console.error("BackendService Request Error", data);
                }
            });
        }
    };
}