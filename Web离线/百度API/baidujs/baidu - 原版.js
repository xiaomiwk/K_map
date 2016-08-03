window.BMAP_AUTHENTIC_KEY = "E4805d16520de693a3fe707cdc962045";
(function () {
    function aa(a) {
        throw a;
    }
    var j = void 0,
        o = !0,
        p = null,
        q = !1;

    function s() {
        return function () {}
    }

    function ba(a) {
        return function (b) {
            this[a] = b
        }
    }

    function u(a) {
        return function () {
            return this[a]
        }
    }

    function da(a) {
        return function () {
            return a
        }
    }
    var ea, fa = [];

    function ga(a) {
        return function () {
            return fa[a].apply(this, arguments)
        }
    }

    function ia(a, b) {
        return fa[a] = b
    }
    var ja, w = ja = w || {
        version: "1.3.4"
    };
    w.Q = "$BAIDU$";
    window[w.Q] = window[w.Q] || {};
    w.object = w.object || {};
    w.extend = w.object.extend = function (a, b) {
        for (var c in b) b.hasOwnProperty(c) && (a[c] = b[c]);
        return a
    };
    w.B = w.B || {};
    w.B.N = function (a) {
        return "string" == typeof a || a instanceof String ? document.getElementById(a) : a && a.nodeName && (1 == a.nodeType || 9 == a.nodeType) ? a : p
    };
    w.N = w.tc = w.B.N;
    w.B.J = function (a) {
        a = w.B.N(a);
        if (a === p) return a;
        a.style.display = "none";
        return a
    };
    w.J = w.B.J;
    w.lang = w.lang || {};
    w.lang.dg = function (a) {
        return "[object String]" == Object.prototype.toString.call(a)
    };
    w.dg = w.lang.dg;
    w.B.vj = function (a) {
        return w.lang.dg(a) ? document.getElementById(a) : a
    };
    w.vj = w.B.vj;
    w.B.contains = function (a, b) {
        var c = w.B.vj,
            a = c(a),
            b = c(b);
        return a.contains ? a != b && a.contains(b) : !!(a.compareDocumentPosition(b) & 16)
    };
    w.S = w.S || {};
    /msie (\d+\.\d)/i.test(navigator.userAgent) && (w.S.ba = w.ba = document.documentMode || +RegExp.$1);
    var la = {
        cellpadding: "cellPadding",
        cellspacing: "cellSpacing",
        colspan: "colSpan",
        rowspan: "rowSpan",
        valign: "vAlign",
        usemap: "useMap",
        frameborder: "frameBorder"
    };
    8 > w.S.ba ? (la["for"] = "htmlFor", la["class"] = "className") : (la.htmlFor = "for", la.className = "class");
    w.B.GF = la;
    w.B.xE = function (a, b, c) {
        a = w.B.N(a);
        if (a === p) return a;
        if ("style" == b) a.style.cssText = c;
        else {
            b = w.B.GF[b] || b;
            a.setAttribute(b, c)
        }
        return a
    };
    w.xE = w.B.xE;
    w.B.yE = function (a, b) {
        a = w.B.N(a);
        if (a === p) return a;
        for (var c in b) w.B.xE(a, c, b[c]);
        return a
    };
    w.yE = w.B.yE;
    w.tk = w.tk || {};
    (function () {
        var a = RegExp("(^[\\s\\t\\xa0\\u3000]+)|([\\u3000\\xa0\\s\\t]+$)", "g");
        w.tk.trim = function (b) {
            return ("" + b).replace(a, "")
        }
    })();
    w.trim = w.tk.trim;
    w.tk.Ol = function (a, b) {
        var a = "" + a,
            c = Array.prototype.slice.call(arguments, 1),
            d = Object.prototype.toString;
        if (c.length) {
            c = c.length == 1 ? b !== p && /\[object Array\]|\[object Object\]/.test(d.call(b)) ? b : c : c;
            return a.replace(/#\{(.+?)\}/g, function (a, b) {
                var g = c[b];
                "[object Function]" == d.call(g) && (g = g(b));
                return "undefined" == typeof g ? "" : g
            })
        }
        return a
    };
    w.Ol = w.tk.Ol;
    w.B.Xb = function (a, b) {
        a = w.B.N(a);
        if (a === p) return a;
        for (var c = a.className.split(/\s+/), d = b.split(/\s+/), e, f = d.length, g, i = 0; i < f; ++i) {
            g = 0;
            for (e = c.length; g < e; ++g)
                if (c[g] == d[i]) {
                    c.splice(g, 1);
                    break
                }
        }
        a.className = c.join(" ");
        return a
    };
    w.Xb = w.B.Xb;
    w.B.Tw = function (a, b, c) {
        a = w.B.N(a);
        if (a === p) return a;
        var d;
        if (a.insertAdjacentHTML) a.insertAdjacentHTML(b, c);
        else {
            d = a.ownerDocument.createRange();
            b = b.toUpperCase();
            if (b == "AFTERBEGIN" || b == "BEFOREEND") {
                d.selectNodeContents(a);
                d.collapse(b == "AFTERBEGIN")
            } else {
                b = b == "BEFOREBEGIN";
                d[b ? "setStartBefore" : "setEndAfter"](a);
                d.collapse(b)
            }
            d.insertNode(d.createContextualFragment(c))
        }
        return a
    };
    w.Tw = w.B.Tw;
    w.B.show = function (a) {
        a = w.B.N(a);
        if (a === p) return a;
        a.style.display = "";
        return a
    };
    w.show = w.B.show;
    w.B.SC = function (a) {
        a = w.B.N(a);
        return a === p ? a : a.nodeType == 9 ? a : a.ownerDocument || a.document
    };
    w.B.Ya = function (a, b) {
        a = w.B.N(a);
        if (a === p) return a;
        for (var c = b.split(/\s+/), d = a.className, e = " " + d + " ", f = 0, g = c.length; f < g; f++) e.indexOf(" " + c[f] + " ") < 0 && (d = d + (" " + c[f]));
        a.className = d;
        return a
    };
    w.Ya = w.B.Ya;
    w.B.OA = w.B.OA || {};
    w.B.kl = w.B.kl || [];
    w.B.kl.filter = function (a, b, c) {
        for (var d = 0, e = w.B.kl, f; f = e[d]; d++)
            if (f = f[c]) b = f(a, b);
        return b
    };
    w.tk.WM = function (a) {
        return a.indexOf("-") < 0 && a.indexOf("_") < 0 ? a : a.replace(/[-_][^-_]/g, function (a) {
            return a.charAt(1).toUpperCase()
        })
    };
    w.B.S1 = function (a, b) {
        w.B.ns(a, b) ? w.B.Xb(a, b) : w.B.Ya(a, b)
    };
    w.B.ns = function (a) {
        if (arguments.length <= 0 || typeof a === "function") return this;
        if (this.size() <= 0) return q;
        var a = a.replace(/^\s+/g, "").replace(/\s+$/g, "").replace(/\s+/g, " "),
            b = a.split(" "),
            c;
        w.forEach(this, function (a) {
            for (var a = a.className, e = 0; e < b.length; e++)
                if (!~(" " + a + " ").indexOf(" " + b[e] + " ")) {
                    c = q;
                    return
                }
            c !== q && (c = o)
        });
        return c
    };
    w.B.Zi = function (a, b) {
        var c = w.B,
            a = c.N(a);
        if (a === p) return a;
        var b = w.tk.WM(b),
            d = a.style[b];
        if (!d) var e = c.OA[b],
            d = a.currentStyle || (w.S.ba ? a.style : getComputedStyle(a, p)),
            d = e && e.get ? e.get(a, d) : d[e || b];
        if (e = c.kl) d = e.filter(b, d, "get");
        return d
    };
    w.Zi = w.B.Zi;
    /opera\/(\d+\.\d)/i.test(navigator.userAgent) && (w.S.opera = +RegExp.$1);
    w.S.XK = /webkit/i.test(navigator.userAgent);
    w.S.pW = /gecko/i.test(navigator.userAgent) && !/like gecko/i.test(navigator.userAgent);
    w.S.ED = "CSS1Compat" == document.compatMode;
    w.B.V = function (a) {
        a = w.B.N(a);
        if (a === p) return a;
        var b = w.B.SC(a),
            c = w.S,
            d = w.B.Zi;
        c.pW > 0 && b.getBoxObjectFor && d(a, "position");
        var e = {
                left: 0,
                top: 0
            },
            f;
        if (a == (c.ba && !c.ED ? b.body : b.documentElement)) return e;
        if (a.getBoundingClientRect) {
            a = a.getBoundingClientRect();
            e.left = Math.floor(a.left) + Math.max(b.documentElement.scrollLeft, b.body.scrollLeft);
            e.top = Math.floor(a.top) + Math.max(b.documentElement.scrollTop, b.body.scrollTop);
            e.left = e.left - b.documentElement.clientLeft;
            e.top = e.top - b.documentElement.clientTop;
            a = b.body;
            b = parseInt(d(a, "borderLeftWidth"));
            d = parseInt(d(a, "borderTopWidth"));
            if (c.ba && !c.ED) {
                e.left = e.left - (isNaN(b) ? 2 : b);
                e.top = e.top - (isNaN(d) ? 2 : d)
            }
        } else {
            f = a;
            do {
                e.left = e.left + f.offsetLeft;
                e.top = e.top + f.offsetTop;
                if (c.XK > 0 && d(f, "position") == "fixed") {
                    e.left = e.left + b.body.scrollLeft;
                    e.top = e.top + b.body.scrollTop;
                    break
                }
                f = f.offsetParent
            } while (f && f != a);
            if (c.opera > 0 || c.XK > 0 && d(a, "position") == "absolute") e.top = e.top - b.body.offsetTop;
            for (f = a.offsetParent; f && f != b.body;) {
                e.left = e.left - f.scrollLeft;
                if (!c.opera || f.tagName != "TR") e.top = e.top - f.scrollTop;
                f = f.offsetParent
            }
        }
        return e
    };
    /firefox\/(\d+\.\d)/i.test(navigator.userAgent) && (w.S.Ig = +RegExp.$1);
    /BIDUBrowser/i.test(navigator.userAgent) && (w.S.q_ = o);
    var ma = navigator.userAgent;
    /(\d+\.\d)?(?:\.\d)?\s+safari\/?(\d+\.\d+)?/i.test(ma) && !/chrome/i.test(ma) && (w.S.rM = +(RegExp.$1 || RegExp.$2));
    /chrome\/(\d+\.\d)/i.test(navigator.userAgent) && (w.S.$I = +RegExp.$1);
    w.Zb = w.Zb || {};
    w.Zb.Fb = function (a, b) {
        var c, d, e = a.length;
        if ("function" == typeof b)
            for (d = 0; d < e; d++) {
                c = a[d];
                c = b.call(a, c, d);
                if (c === q) break
            }
        return a
    };
    w.Fb = w.Zb.Fb;
    w.lang.Q = function () {
        return "TANGRAM__" + (window[w.Q]._counter++).toString(36)
    };
    window[w.Q]._counter = window[w.Q]._counter || 1;
    window[w.Q]._instances = window[w.Q]._instances || {};
    w.lang.xs = function (a) {
        return "[object Function]" == Object.prototype.toString.call(a)
    };
    w.lang.ra = function (a) {
        this.Q = a || w.lang.Q();
        window[w.Q]._instances[this.Q] = this
    };
    window[w.Q]._instances = window[w.Q]._instances || {};
    w.lang.ra.prototype.Nh = ga(0);
    w.lang.ra.prototype.toString = function () {
        return "[object " + (this.VO || "Object") + "]"
    };
    w.lang.jy = function (a, b) {
        this.type = a;
        this.returnValue = o;
        this.target = b || p;
        this.currentTarget = p
    };
    w.lang.ra.prototype.addEventListener = function (a, b, c) {
        if (w.lang.xs(b)) {
            !this.ni && (this.ni = {});
            var d = this.ni,
                e;
            if (typeof c == "string" && c) {
                /[^\w\-]/.test(c) && aa("nonstandard key:" + c);
                e = b.zK = c
            }
            a.indexOf("on") != 0 && (a = "on" + a);
            typeof d[a] != "object" && (d[a] = {});
            e = e || w.lang.Q();
            b.zK = e;
            d[a][e] = b
        }
    };
    w.lang.ra.prototype.removeEventListener = function (a, b) {
        if (w.lang.xs(b)) b = b.zK;
        else if (!w.lang.dg(b)) return;
        !this.ni && (this.ni = {});
        a.indexOf("on") != 0 && (a = "on" + a);
        var c = this.ni;
        c[a] && c[a][b] && delete c[a][b]
    };
    w.lang.ra.prototype.dispatchEvent = function (a, b) {
        w.lang.dg(a) && (a = new w.lang.jy(a));
        !this.ni && (this.ni = {});
        var b = b || {},
            c;
        for (c in b) a[c] = b[c];
        var d = this.ni,
            e = a.type;
        a.target = a.target || this;
        a.currentTarget = this;
        e.indexOf("on") != 0 && (e = "on" + e);
        w.lang.xs(this[e]) && this[e].apply(this, arguments);
        if (typeof d[e] == "object")
            for (c in d[e]) d[e][c].apply(this, arguments);
        return a.returnValue
    };
    w.lang.ja = function (a, b, c) {
        var d, e, f = a.prototype;
        e = new Function;
        e.prototype = b.prototype;
        e = a.prototype = new e;
        for (d in f) e[d] = f[d];
        a.prototype.constructor = a;
        a.BY = b.prototype;
        if ("string" == typeof c) e.VO = c
    };
    w.ja = w.lang.ja;
    w.lang.Md = function (a) {
        return window[w.Q]._instances[a] || p
    };
    w.platform = w.platform || {};
    w.platform.QK = /macintosh/i.test(navigator.userAgent);
    w.platform.M0 = /MicroMessenger/i.test(navigator.userAgent);
    w.platform.YK = /windows/i.test(navigator.userAgent);
    w.platform.xW = /x11/i.test(navigator.userAgent);
    w.platform.ek = /android/i.test(navigator.userAgent);
    /android (\d+\.\d)/i.test(navigator.userAgent) && (w.platform.KI = w.KI = RegExp.$1);
    w.platform.rW = /ipad/i.test(navigator.userAgent);
    w.platform.AD = /iphone/i.test(navigator.userAgent);

    function na(a, b) {
        a.domEvent = b = window.event || b;
        a.clientX = b.clientX || b.pageX;
        a.clientY = b.clientY || b.pageY;
        a.offsetX = b.offsetX || b.layerX;
        a.offsetY = b.offsetY || b.layerY;
        a.screenX = b.screenX;
        a.screenY = b.screenY;
        a.ctrlKey = b.ctrlKey || b.metaKey;
        a.shiftKey = b.shiftKey;
        a.altKey = b.altKey;
        if (b.touches) {
            a.touches = [];
            for (var c = 0; c < b.touches.length; c++) a.touches.push({
                clientX: b.touches[c].clientX,
                clientY: b.touches[c].clientY,
                screenX: b.touches[c].screenX,
                screenY: b.touches[c].screenY,
                pageX: b.touches[c].pageX,
                pageY: b.touches[c].pageY,
                target: b.touches[c].target,
                identifier: b.touches[c].identifier
            })
        }
        if (b.changedTouches) {
            a.changedTouches = [];
            for (c = 0; c < b.changedTouches.length; c++) a.changedTouches.push({
                clientX: b.changedTouches[c].clientX,
                clientY: b.changedTouches[c].clientY,
                screenX: b.changedTouches[c].screenX,
                screenY: b.changedTouches[c].screenY,
                pageX: b.changedTouches[c].pageX,
                pageY: b.changedTouches[c].pageY,
                target: b.changedTouches[c].target,
                identifier: b.changedTouches[c].identifier
            })
        }
        if (b.targetTouches) {
            a.targetTouches = [];
            for (c = 0; c < b.targetTouches.length; c++) a.targetTouches.push({
                clientX: b.targetTouches[c].clientX,
                clientY: b.targetTouches[c].clientY,
                screenX: b.targetTouches[c].screenX,
                screenY: b.targetTouches[c].screenY,
                pageX: b.targetTouches[c].pageX,
                pageY: b.targetTouches[c].pageY,
                target: b.targetTouches[c].target,
                identifier: b.targetTouches[c].identifier
            })
        }
        a.rotation = b.rotation;
        a.scale = b.scale;
        return a
    }
    w.lang.fw = function (a) {
        var b = window[w.Q];
        b.XQ && delete b.XQ[a]
    };
    w.event = {};
    w.F = w.event.F = function (a, b, c) {
        if (!(a = w.N(a))) return a;
        b = b.replace(/^on/, "");
        a.addEventListener ? a.addEventListener(b, c, q) : a.attachEvent && a.attachEvent("on" + b, c);
        return a
    };
    w.je = w.event.je = function (a, b, c) {
        if (!(a = w.N(a))) return a;
        b = b.replace(/^on/, "");
        a.removeEventListener ? a.removeEventListener(b, c, q) : a.detachEvent && a.detachEvent("on" + b, c);
        return a
    };
    w.B.ns = function (a, b) {
        if (!a || !a.className || typeof a.className != "string") return q;
        var c = -1;
        try {
            c = a.className == b || a.className.search(RegExp("(\\s|^)" + b + "(\\s|$)"))
        } catch (d) {
            return q
        }
        return c > -1
    };
    w.KJ = function () {
        function a(a) {
            document.addEventListener && (this.element = a, this.NJ = this.bk ? "touchstart" : "mousedown", this.AC = this.bk ? "touchmove" : "mousemove", this.zC = this.bk ? "touchend" : "mouseup", this.Wg = q, this.mt = this.lt = 0, this.element.addEventListener(this.NJ, this, q), ja.F(this.element, "mousedown", s()), this.handleEvent(p))
        }
        a.prototype = {
            bk: "ontouchstart" in window || "createTouch" in document,
            start: function (a) {
                oa(a);
                this.Wg = q;
                this.lt = this.bk ? a.touches[0].clientX : a.clientX;
                this.mt = this.bk ? a.touches[0].clientY : a.clientY;
                this.element.addEventListener(this.AC, this, q);
                this.element.addEventListener(this.zC, this, q)
            },
            move: function (a) {
                pa(a);
                var c = this.bk ? a.touches[0].clientY : a.clientY;
                if (10 < Math.abs((this.bk ? a.touches[0].clientX : a.clientX) - this.lt) || 10 < Math.abs(c - this.mt)) this.Wg = o
            },
            end: function (a) {
                pa(a);
                this.Wg || (a = document.createEvent("Event"), a.initEvent("tap", q, o), this.element.dispatchEvent(a));
                this.element.removeEventListener(this.AC, this, q);
                this.element.removeEventListener(this.zC, this, q)
            },
            handleEvent: function (a) {
                if (a) switch (a.type) {
                case this.NJ:
                    this.start(a);
                    break;
                case this.AC:
                    this.move(a);
                    break;
                case this.zC:
                    this.end(a)
                }
            }
        };
        return function (b) {
            return new a(b)
        }
    }();
    var z = window.BMap || {};
    z.version = "2.0";
    z.uI = 0.34 > Math.random();
    0 <= z.version.indexOf("#") && (z.version = "2.0");
    z.Sq = [];
    z.Fe = function (a) {
        this.Sq.push(a)
    };
    z.Iq = [];
    z.rm = function (a) {
        this.Iq.push(a)
    };
    z.iT = z.apiLoad || s();
    var qa = window.BMAP_AUTHENTIC_KEY;
    window.BMAP_AUTHENTIC_KEY = p;
    var ra = window.BMap_loadScriptTime,
        sa = (new Date).getTime(),
        ta = p,
        ua = o,
        va = p,
        wa = 5042,
        xa = 5002,
        ya = 5003,
        Aa = "load_mapclick",
        Ba = 5038,
        Ca = 5041,
        Da = 5047,
        Ea = 5036,
        Fa = 5039,
        Ga = 5037,
        Ha = 5040,
        Ia = 5011,
        Ja = 7E3;

    function Ka(a, b) {
        if (a = w.N(a)) {
            var c = this;
            w.lang.ra.call(c);
            b = b || {};
            c.D = {
                uB: 200,
                Rb: o,
                qw: q,
                sC: o,
                io: o,
                jo: q,
                IJ: o,
                uC: o,
                Ur: o,
                nw: o,
                Ml: o,
                fo: b.enable3DBuilding || q,
                Lc: 25,
                vZ: 240,
                XS: 450,
                Kb: E.Kb,
                ld: E.ld,
                Vw: !!b.Vw,
                Tb: Math.round(b.minZoom) || 1,
                Mb: Math.round(b.maxZoom) || 19,
                lb: b.mapType || La,
                y1: q,
                ow: o,
                lw: 500,
                DU: b.enableHighResolution !== q,
                Si: b.enableMapClick !== q,
                devicePixelRatio: b.devicePixelRatio || window.devicePixelRatio || 1,
                WE: b.vectorMapLevel || (G() ? 3 : 99),
                ee: b.mapStyle || p,
                HW: b.logoControl === q ? q : o,
                qT: ["chrome"],
                Nv: b.beforeClickIcon || p
            };
            c.D.ee && (this.gW(c.D.ee.controls), this.KK(c.D.ee.geotableId));
            c.D.ee && c.D.ee.styleId && c.z0(c.D.ee.styleId);
            c.D.El = {
                dark: {
                    backColor: "#2D2D2D",
                    textColor: "#bfbfbf",
                    iconUrl: "dicons"
                },
                normal: {
                    backColor: "#F3F1EC",
                    textColor: "#c61b1b",
                    iconUrl: "icons"
                },
                light: {
                    backColor: "#EBF8FC",
                    textColor: "#017fb4",
                    iconUrl: "licons"
                }
            };
            b.enableAutoResize && (c.D.nw = b.enableAutoResize);
            b.enableStreetEntrance === q && (c.D.Ml = b.enableStreetEntrance);
            b.enableDeepZoom === q && (c.D.IJ = b.enableDeepZoom);
            w.platform.ek && 1.5 < window.devicePixelRatio && (c.D.devicePixelRatio = 1.5);
            var d = c.D.qT;
            if (G())
                for (var e = 0, f = d.length; e < f; e++)
                    if (w.S[d[e]]) {
                        c.D.devicePixelRatio = 1;
                        break
                    }
            d = -1 < navigator.userAgent.toLowerCase().indexOf("android");
            e = -1 < navigator.userAgent.toLowerCase().indexOf("mqqbrowser");
            if (-1 < navigator.userAgent.toLowerCase().indexOf("UCBrowser") || d && e) c.D.WE = 99, c.D.DU = q, c.D.devicePixelRatio = 1;
            c.Ia = a;
            c.HA(a);
            a.unselectable = "on";
            a.innerHTML = "";
            a.appendChild(c.la());
            b.size && this.sd(b.size);
            d = c.Lb();
            c.width = d.width;
            c.height = d.height;
            c.offsetX = 0;
            c.offsetY = 0;
            c.platform = a.firstChild;
            c.fe = c.platform.firstChild;
            c.fe.style.width = c.width + "px";
            c.fe.style.height = c.height + "px";
            c.Xd = {};
            c.Pe = new H(0, 0);
            c.hc = new H(0, 0);
            c.va = 3;
            c.xc = 0;
            c.NB = p;
            c.MB = p;
            c.Jb = "";
            c.Rv = "";
            c.uh = {};
            c.uh.custom = {};
            c.Ea = 0;
            c.G = new Na(a, {
                yf: "api"
            });
            c.G.J();
            c.G.AE(c);
            b = b || {};
            d = c.lb = c.D.lb;
            c.Sd = d.vo();
            d === Oa && Pa(xa);
            d === Qa && Pa(ya);
            d = c.D;
            d.oN = Math.round(b.minZoom);
            d.nN = Math.round(b.maxZoom);
            c.hu();
            c.H = {
                yc: q,
                Wb: 0,
                Bs: 0,
                cL: 0,
                Q0: 0,
                mB: q,
                kE: -1,
                Ae: []
            };
            c.platform.style.cursor = c.D.Kb;
            for (e = 0; e < z.Sq.length; e++) z.Sq[e](c);
            c.H.kE = e;
            c.P();
            I.load("map", function () {
                c.rb()
            });
            c.D.Si && (setTimeout(function () {
                Pa(Aa)
            }, 1E3), I.load("mapclick", function () {
                window.MPC_Mgr = window.MPC_Mgr || {};
                window.MPC_Mgr[c.Q] = new Sa(c)
            }, o));
            Ta() && I.load("oppc", function () {
                c.Dy()
            });
            G() && I.load("opmb", function () {
                c.Dy()
            });
            a = p;
            c.VA = []
        }
    }
    w.lang.ja(Ka, w.lang.ra, "Map");
    w.extend(Ka.prototype, {
        la: function () {
            var a = J("div"),
                b = a.style;
            b.overflow = "visible";
            b.position = "absolute";
            b.zIndex = "0";
            b.top = b.left = "0px";
            var b = J("div", {
                    "class": "BMap_mask"
                }),
                c = b.style;
            c.position = "absolute";
            c.top = c.left = "0px";
            c.zIndex = "9";
            c.overflow = "hidden";
            c.WebkitUserSelect = "none";
            a.appendChild(b);
            return a
        },
        HA: function (a) {
            var b = a.style;
            b.overflow = "hidden";
            "absolute" !== Ua(a).position && (b.position = "relative", b.zIndex = 0);
            b.backgroundColor = "#F3F1EC";
            b.color = "#000";
            b.textAlign = "left"
        },
        P: function () {
            var a = this;
            a.pr = function () {
                var b = a.Lb();
                if (a.width !== b.width || a.height !== b.height) {
                    var c = new K(a.width, a.height),
                        d = new L("onbeforeresize");
                    d.size = c;
                    a.dispatchEvent(d);
                    a.Kj((b.width - a.width) / 2, (b.height - a.height) / 2);
                    a.fe.style.width = (a.width = b.width) + "px";
                    a.fe.style.height = (a.height = b.height) + "px";
                    c = new L("onresize");
                    c.size = b;
                    a.dispatchEvent(c)
                }
            };
            a.D.nw && (a.H.tr = setInterval(a.pr, 80))
        },
        Kj: function (a, b, c, d) {
            var e = this.ia().gc(this.U()),
                f = this.Sd,
                g = o;
            c && H.PK(c) && (this.Pe = new H(c.lng, c.lat), g = q);
            if (c = c && d ? f.im(c, this.Jb) : this.hc)
                if (this.hc = new H(c.lng + a * e, c.lat - b * e), (a = f.Vg(this.hc, this.Jb)) && g) this.Pe = a
        },
        ng: function (a, b) {
            if (Va(a) && (this.hu(), this.dispatchEvent(new L("onzoomstart")), a = this.mn(a).zoom, a !== this.va)) {
                this.xc = this.va;
                this.va = a;
                var c;
                b ? c = b : this.Mg() && (c = this.Mg().V());
                c && (c = this.Ub(c, this.xc), this.Kj(this.width / 2 - c.x, this.height / 2 - c.y, this.nb(c, this.xc), o));
                this.dispatchEvent(new L("onzoomstartcode"))
            }
        },
        Bc: function (a) {
            this.ng(a)
        },
        $E: function (a) {
            this.ng(this.va + 1, a)
        },
        aF: function (a) {
            this.ng(this.va - 1, a)
        },
        $h: function (a) {
            a instanceof H && (this.hc = this.Sd.im(a, this.Jb), this.Pe = H.PK(a) ? new H(a.lng, a.lat) : this.Sd.Vg(this.hc, this.Jb))
        },
        hg: function (a, b) {
            a = Math.round(a) || 0;
            b = Math.round(b) || 0;
            this.Kj(-a, -b)
        },
        Dv: function (a) {
            a && Wa(a.Le) && (a.Le(this), this.dispatchEvent(new L("onaddcontrol", a)))
        },
        gM: function (a) {
            a && Wa(a.remove) && (a.remove(), this.dispatchEvent(new L("onremovecontrol", a)))
        },
        On: function (a) {
            a && Wa(a.fa) && (a.fa(this), this.dispatchEvent(new L("onaddcontextmenu", a)))
        },
        So: function (a) {
            a && Wa(a.remove) && (this.dispatchEvent(new L("onremovecontextmenu", a)), a.remove())
        },
        xa: function (a) {
            a && Wa(a.Le) && (a.Le(this), this.dispatchEvent(new L("onaddoverlay", a)))
        },
        Hb: function (a) {
            a && Wa(a.remove) && (a.remove(), this.dispatchEvent(new L("onremoveoverlay", a)))
        },
        cJ: function () {
            this.dispatchEvent(new L("onclearoverlays"))
        },
        Cg: function (a) {
            a && this.dispatchEvent(new L("onaddtilelayer", a))
        },
        dh: function (a) {
            a && this.dispatchEvent(new L("onremovetilelayer", a))
        },
        jg: function (a) {
            if (this.lb !== a) {
                var b = new L("onsetmaptype");
                b.p1 = this.lb;
                this.lb = this.D.lb = a;
                this.Sd = this.lb.vo();
                this.Kj(0, 0, this.za(), o);
                this.hu();
                var c = this.mn(this.U()).zoom;
                this.ng(c);
                this.dispatchEvent(b);
                b = new L("onmaptypechange");
                b.va = c;
                b.lb = a;
                this.dispatchEvent(b);
                (a === Xa || a === Qa) && Pa(ya)
            }
        },
        Gf: function (a) {
            var b = this;
            if (a instanceof H) b.$h(a, {
                noAnimation: o
            });
            else if (Ya(a))
                if (b.lb === Oa) {
                    var c = E.qB[a];
                    c && (pt = c.m, b.Gf(pt))
                } else {
                    var d = this.IG();
                    d.DE(function (c) {
                        0 === d.Vl() && 2 === d.ta.result.type && (b.Gf(c.Zj(0).point), Oa.Vj(a) && b.zE(a))
                    });
                    d.search(a, {
                        log: "center"
                    })
                }
        },
        Zd: function (a, b) {
            "[object Undefined]" !== Object.prototype.toString.call(b) && (b = parseInt(b));
            va = G() ? Za.li.Qj(z.uI ? 102 : 101) : Za.li.Qj(1);
            va.nt();
            va.wy = +new Date;
            va.$b("script_loaded", sa - ra);
            va.$b("centerAndZoom");
            var c = this;
            if (Ya(a))
                if (c.lb === Oa) {
                    var d = E.qB[a];
                    d && (pt = d.m, c.Zd(pt, b))
                } else {
                    var e = c.IG();
                    e.DE(function (d) {
                        if (0 === e.Vl() && (2 === e.ta.result.type || 11 === e.ta.result.type)) {
                            var d = d.Zj(0).point,
                                f = b || N.NC(e.ta.content.level, c);
                            c.Zd(d, f);
                            Oa.Vj(a) && c.zE(a)
                        }
                    });
                    e.search(a, {
                        log: "center"
                    })
                } else if (a instanceof H && b) {
                b = c.mn(b).zoom;
                c.xc = c.va || b;
                c.va = b;
                d = c.Pe;
                c.Pe = new H(a.lng, a.lat);
                c.hc = c.Sd.im(c.Pe, c.Jb);
                c.NB = c.NB || c.va;
                c.MB = c.MB || c.Pe;
                var f = new L("onload"),
                    g = new L("onloadcode");
                f.point = new H(a.lng, a.lat);
                f.pixel = c.Ub(c.Pe, c.va);
                f.zoom = b;
                c.loaded || (c.loaded = o, c.dispatchEvent(f), ta || (ta = $a()));
                c.dispatchEvent(g);
                f = new L("onmoveend");
                f.mG = "centerAndZoom";
                d.$a(c.Pe) || c.dispatchEvent(f);
                c.dispatchEvent(new L("onmoveend"));
                c.xc !== c.va && (d = new L("onzoomend"), d.mG = "centerAndZoom", c.dispatchEvent(d));
                c.D.fo && c.fo()
            }
        },
        IG: function () {
            this.H.hL || (this.H.hL = new bb(1));
            return this.H.hL
        },
        reset: function () {
            this.Zd(this.MB, this.NB, o)
        },
        enableDragging: function () {
            this.D.Rb = o
        },
        disableDragging: function () {
            this.D.Rb = q
        },
        enableInertialDragging: function () {
            this.D.ow = o
        },
        disableInertialDragging: function () {
            this.D.ow = q
        },
        enableScrollWheelZoom: function () {
            this.D.jo = o
        },
        disableScrollWheelZoom: function () {
            this.D.jo = q
        },
        enableContinuousZoom: function () {
            this.D.io = o
        },
        disableContinuousZoom: function () {
            this.D.io = q
        },
        enableDoubleClickZoom: function () {
            this.D.sC = o
        },
        disableDoubleClickZoom: function () {
            this.D.sC = q
        },
        enableKeyboard: function () {
            this.D.qw = o
        },
        disableKeyboard: function () {
            this.D.qw = q
        },
        enablePinchToZoom: function () {
            this.D.Ur = o
        },
        disablePinchToZoom: function () {
            this.D.Ur = q
        },
        enableAutoResize: function () {
            this.D.nw = o;
            this.pr();
            this.H.tr || (this.H.tr = setInterval(this.pr, 80))
        },
        disableAutoResize: function () {
            this.D.nw = q;
            this.H.tr && (clearInterval(this.H.tr), this.H.tr = p)
        },
        fo: function () {
            this.D.fo = o;
            this.$m || (this.$m = new cb({
                RJ: o
            }), this.Cg(this.$m))
        },
        nU: function () {
            this.D.fo = q;
            this.$m && (this.dh(this.$m), this.$m = p, delete this.$m)
        },
        Lb: function () {
            return this.Hr && this.Hr instanceof K ? new K(this.Hr.width, this.Hr.height) : new K(this.Ia.clientWidth, this.Ia.clientHeight)
        },
        sd: function (a) {
            a && a instanceof K ? (this.Hr = a, this.Ia.style.width = a.width + "px", this.Ia.style.height = a.height + "px") : this.Hr = p
        },
        za: u("Pe"),
        U: u("va"),
        IT: function () {
            this.pr()
        },
        mn: function (a) {
            var b = this.D.Tb,
                c = this.D.Mb,
                d = q,
                a = Math.round(a);
            a < b && (d = o, a = b);
            a > c && (d = o, a = c);
            return {
                zoom: a,
                BC: d
            }
        },
        Fa: u("Ia"),
        Ub: function (a, b) {
            b = b || this.U();
            return this.Sd.Ub(a, b, this.hc, this.Lb(), this.Jb)
        },
        nb: function (a, b) {
            b = b || this.U();
            return this.Sd.nb(a, b, this.hc, this.Lb(), this.Jb)
        },
        Ee: function (a, b) {
            if (a) {
                var c = this.Ub(new H(a.lng, a.lat), b);
                c.x -= this.offsetX;
                c.y -= this.offsetY;
                return c
            }
        },
        XL: function (a, b) {
            if (a) {
                var c = new P(a.x, a.y);
                c.x += this.offsetX;
                c.y += this.offsetY;
                return this.nb(c, b)
            }
        },
        pointToPixelFor3D: function (a, b) {
            var c = map.Jb;
            this.lb === Oa && c && db.iJ(a, this, b)
        },
        k1: function (a, b) {
            var c = map.Jb;
            this.lb === Oa && c && db.hJ(a, this, b)
        },
        l1: function (a, b) {
            var c = this,
                d = map.Jb;
            c.lb === Oa && d && db.iJ(a, c, function (a) {
                a.x -= c.offsetX;
                a.y -= c.offsetY;
                b && b(a)
            })
        },
        j1: function (a, b) {
            var c = map.Jb;
            this.lb === Oa && c && (a.x += this.offsetX, a.y += this.offsetY, db.hJ(a, this, b))
        },
        Ld: function (a) {
            if (!this.Uw()) return new eb;
            var b = a || {},
                a = b.margins || [0, 0, 0, 0],
                c = b.zoom || p,
                b = this.nb({
                    x: a[3],
                    y: this.height - a[2]
                }, c),
                a = this.nb({
                    x: this.width - a[1],
                    y: a[0]
                }, c);
            return new eb(b, a)
        },
        Uw: function () {
            return !!this.loaded
        },
        gQ: function (a, b) {
            for (var c = this.ia(), d = b.margins || [10, 10, 10, 10], e = b.zoomFactor || 0, f = d[1] + d[3], d = d[0] + d[2], g = c.qo(), i = c = c.Sl(); i >= g; i--) {
                var k = this.ia().gc(i);
                if (a.QE().lng / k < this.width - f && a.QE().lat / k < this.height - d) break
            }
            i += e;
            i < g && (i = g);
            i > c && (i = c);
            return i
        },
        ls: function (a, b) {
            var c = {
                center: this.za(),
                zoom: this.U()
            };
            if (!a || !a instanceof eb && 0 === a.length || a instanceof eb && a.ej()) return c;
            var d = [];
            a instanceof eb ? (d.push(a.zf()), d.push(a.Ce())) : d = a.slice(0);
            for (var b = b || {}, e = [], f = 0, g = d.length; f < g; f++) e.push(this.Sd.im(d[f], this.Jb));
            d = new eb;
            for (f = e.length - 1; 0 <= f; f--) d.extend(e[f]);
            if (d.ej()) return c;
            c = d.za();
            e = this.gQ(d, b);
            b.margins && (d = b.margins, f = (d[1] - d[3]) / 2, d = (d[0] - d[2]) / 2, g = this.ia().gc(e), b.offset && (f = b.offset.width, d = b.offset.height), c.lng += g * f, c.lat += g * d);
            c = this.Sd.Vg(c, this.Jb);
            return {
                center: c,
                zoom: e
            }
        },
        fh: function (a, b) {
            var c;
            c = a && a.center ? a : this.ls(a, b);
            var b = b || {},
                d = b.delay || 200;
            if (c.zoom === this.va && b.enableAnimation !== q) {
                var e = this;
                setTimeout(function () {
                    e.$h(c.center, {
                        duration: 210
                    })
                }, d)
            } else this.Zd(c.center, c.zoom)
        },
        Bf: u("Xd"),
        Mg: function () {
            return this.H.ab && this.H.ab.Ja() ? this.H.ab : p
        },
        getDistance: function (a, b) {
            if (a && b) {
                if (a.$a(b)) return 0;
                var c = 0,
                    c = Q.oo(a, b);
                if (c === p || c === j) c = 0;
                return c
            }
        },
        bD: function () {
            var a = [],
                b = this.ka,
                c = this.me;
            if (b)
                for (var d in b) b[d] instanceof fb && a.push(b[d]);
            if (c) {
                d = 0;
                for (b = c.length; d < b; d++) a.push(c[d])
            }
            return a
        },
        ia: u("lb"),
        Dy: function () {
            for (var a = this.H.kE; a < z.Sq.length; a++) z.Sq[a](this);
            this.H.kE = a
        },
        zE: function (a) {
            this.Jb = Oa.Vj(a);
            this.Rv = Oa.aK(this.Jb);
            this.lb === Oa && this.Sd instanceof gb && (this.Sd.GB = this.Jb)
        },
        setDefaultCursor: function (a) {
            this.D.Kb = a;
            this.platform && (this.platform.style.cursor = this.D.Kb)
        },
        getDefaultCursor: function () {
            return this.D.Kb
        },
        setDraggingCursor: function (a) {
            this.D.ld = a
        },
        getDraggingCursor: function () {
            return this.D.ld
        },
        Og: da(q),
        Fv: function (a, b) {
            b ? this.uh[b] || (this.uh[b] = {}) : b = "custom";
            a.tag = b;
            a instanceof hb && (this.uh[b][a.Q] = a, a.fa(this));
            var c = this;
            I.load("hotspot", function () {
                c.Dy()
            }, o)
        },
        uX: function (a, b) {
            b || (b = "custom");
            this.uh[b][a.Q] && delete this.uh[b][a.Q]
        },
        Cl: function (a) {
            a || (a = "custom");
            this.uh[a] = {}
        },
        hu: function () {
            var a = this.Og() ? this.lb.k.ZV : this.lb.qo(),
                b = this.Og() ? this.lb.k.Qw : this.lb.Sl(),
                c = this.D;
            c.Tb = c.oN || a;
            c.Mb = c.nN || b;
            c.Tb < a && (c.Tb = a);
            c.Mb > b && (c.Mb = b)
        },
        setMinZoom: function (a) {
            a = Math.round(a);
            a > this.D.Mb && (a = this.D.Mb);
            this.D.oN = a;
            this.lI()
        },
        setMaxZoom: function (a) {
            a = Math.round(a);
            a < this.D.Tb && (a = this.D.Tb);
            this.D.nN = a;
            this.lI()
        },
        lI: function () {
            this.hu();
            var a = this.D;
            this.va < a.Tb ? this.Bc(a.Tb) : this.va > a.Mb && this.Bc(a.Mb);
            var b = new L("onzoomspanchange");
            b.Tb = a.Tb;
            b.Mb = a.Mb;
            this.dispatchEvent(b)
        },
        B0: u("VA"),
        getKey: function () {
            return qa
        },
        Xs: function (a) {
            var b = this;
            window.MPC_Mgr && window.MPC_Mgr[b.Q] && window.MPC_Mgr[b.Q].close();
            b.D.Si = q;
            if (a) {
                b = this;
                a.styleJson && (a.styleStr = b.yY(a.styleJson));
                G() && w.S.rM ? setTimeout(function () {
                    b.D.ee = a;
                    b.dispatchEvent(new L("onsetcustomstyles", a))
                }, 50) : (this.D.ee = a, this.dispatchEvent(new L("onsetcustomstyles", a)), this.KK(b.D.ee.geotableId));
                var c = {
                    style: a.style
                };
                a.features && 0 < a.features.length && (c.features = o);
                a.styleJson && 0 < a.styleJson.length && (c.styleJson = o);
                Pa(5050, c);
                a.style && (c = b.D.El[a.style] ? b.D.El[a.style].backColor : b.D.El.normal.backColor) && (this.Fa().style.backgroundColor = c)
            }
        },
        gW: function (a) {
            this.controls || (this.controls = {
                navigationControl: new ib,
                scaleControl: new jb,
                overviewMapControl: new lb,
                mapTypeControl: new mb
            });
            var b = this,
                c;
            for (c in this.controls) b.gM(b.controls[c]);
            a = a || [];
            w.Zb.Fb(a, function (a) {
                b.Dv(b.controls[a])
            })
        },
        KK: function (a) {
            a ? this.Fr && this.Fr.Pf === a || (this.dh(this.Fr), this.Fr = new nb({
                geotableId: a
            }), this.Cg(this.Fr)) : this.dh(this.Fr)
        },
        Ib: function () {
            var a = this.U() >= this.D.WE && this.ia() === La && 18 >= this.U(),
                b = q;
            try {
                document.createElement("canvas").getContext("2d"), b = o
            } catch (c) {
                b = q
            }
            return a && b
        },
        getCurrentCity: function () {
            return {
                name: this.Xn,
                code: this.jB
            }
        },
        getPanorama: u("G"),
        setPanorama: function (a) {
            this.G = a;
            this.G.AE(this)
        },
        yY: function (a) {
            for (var b = {
                    featureType: "t",
                    elementType: "e",
                    visibility: "v",
                    color: "c",
                    lightness: "l",
                    saturation: "s",
                    weight: "w",
                    zoom: "z",
                    hue: "h"
                }, c = {
                    all: "all",
                    geometry: "g",
                    "geometry.fill": "g.f",
                    "geometry.stroke": "g.s",
                    labels: "l",
                    "labels.text.fill": "l.t.f",
                    "labels.text.stroke": "l.t.s",
                    "lables.text": "l.t",
                    "labels.icon": "l.i"
                }, d = [], e = 0, f; f = a[e]; e++) {
                var g = f.stylers;
                delete f.stylers;
                w.extend(f, g);
                var g = [],
                    i;
                for (i in b) f[i] && ("elementType" === i ? g.push(b[i] + ":" + c[f[i]]) : g.push(b[i] + ":" + f[i]));
                2 < g.length && d.push(g.join("|"))
            }
            return d.join(",")
        }
    });

    function Pa(a, b) {
        if (a) {
            var b = b || {},
                c = "",
                d;
            for (d in b) c = c + "&" + d + "=" + encodeURIComponent(b[d]);
            var e = function (a) {
                    a && (ob = o, setTimeout(function () {
                        pb.src = z.wc + "images/blank.gif?" + a.src
                    }, 50))
                },
                f = function () {
                    var a = rb.shift();
                    a && e(a)
                };
            d = (1E8 * Math.random()).toFixed(0);
            ob ? rb.push({
                src: "product=jsapi&sub_product=jsapi&v=" + z.version + "&sub_product_v=" + z.version + "&t=" + d + "&code=" + a + "&da_src=" + a + c
            }) : e({
                src: "product=jsapi&sub_product=jsapi&v=" + z.version + "&sub_product_v=" + z.version + "&t=" + d + "&code=" + a + "&da_src=" + a + c
            });
            sb || (w.F(pb, "load", function () {
                ob = q;
                f()
            }), w.F(pb, "error", function () {
                ob = q;
                f()
            }), sb = o)
        }
    }
    var ob, sb, rb = [],
        pb = new Image;
    Pa(5E3, {
        device_pixel_ratio: window.devicePixelRatio,
        platform: navigator.platform
    });
    z.EK = {
        TILE_BASE_URLS: ["ss0.baidu.com/5bwHcj7lABFU8t_jkk_Z1zRvfdw6buu", "ss0.baidu.com/5bwHcj7lABFV8t_jkk_Z1zRvfdw6buu", "ss0.baidu.com/5bwHcj7lABFS8t_jkk_Z1zRvfdw6buu", "ss0.bdstatic.com/5bwHcj7lABFT8t_jkk_Z1zRvfdw6buu", "ss0.bdstatic.com/5bwHcj7lABFY8t_jkk_Z1zRvfdw6buu"],
        TILE_ONLINE_URLS: ["ss0.bdstatic.com/8bo_dTSlR1gBo1vgoIiO_jowehsv", "ss0.bdstatic.com/8bo_dTSlRMgBo1vgoIiO_jowehsv", "ss0.bdstatic.com/8bo_dTSlRcgBo1vgoIiO_jowehsv", "ss0.bdstatic.com/8bo_dTSlRsgBo1vgoIiO_jowehsv", "ss0.bdstatic.com/8bo_dTSlQ1gBo1vgoIiO_jowehsv"],
        TIlE_PERSPECT_URLS: ["ss0.bdstatic.com/-OR1cTe9KgQFm2e88IuM_a", "ss0.bdstatic.com/-ON1cTe9KgQFm2e88IuM_a", "ss0.bdstatic.com/-OZ1cTe9KgQFm2e88IuM_a", "ss0.bdstatic.com/-OV1cTe9KgQFm2e88IuM_a"],
        geolocControl: "sp2.baidu.com/8LkJsjOpB1gCo2Kml5_Y_D3",
        TILES_YUN_HOST: ["sp0.baidu.com/-eR1bSahKgkFkRGko9WTAnF6hhy", "sp0.baidu.com/-eN1bSahKgkFkRGko9WTAnF6hhy", "sp0.baidu.com/-eZ1bSahKgkFkRGko9WTAnF6hhy", "sp0.baidu.com/-eV1bSahKgkFkRGko9WTAnF6hhy"],
        traffic: "sp0.baidu.com/7_AZsjOpB1gCo2Kml5_Y_D3",
        iw_pano: "ss0.bdstatic.com/5LUZemba_QUU8t7mm9GUKT-xh_",
        message: "sp0.baidu.com/7vo0bSba2gU2pMbgoY3K",
        baidumap: "sp0.baidu.com/80MWsjip0QIZ8tyhnq",
        wuxian: "sp0.baidu.com/6a1OdTeaKgQFm2e88IuM_a",
        pano: ["ss0.bdstatic.com/5LUZemba_QUU8t7mm9GUKT-xh_", "ss0.bdstatic.com/5LUZemfa_QUU8t7mm9GUKT-xh_", "ss0.bdstatic.com/5LUZemja_QUU8t7mm9GUKT-xh_"],
        main_domain_nocdn: {
            baidu: "sp0.baidu.com/9_Q4sjOpB1gCo2Kml5_Y_D3",
            other: "sapi.map.baidu.com"
        },
        main_domain_cdn: {
            baidu: ["ss0.bdstatic.com/9_Q4vHSd2RZ3otebn9fN2DJv", "ss0.baidu.com/9_Q4vXSd2RZ3otebn9fN2DJv", "ss0.bdstatic.com/9_Q4vnSd2RZ3otebn9fN2DJv"],
            other: ["sapi.map.baidu.com"]
        },
        map_click: "sp0.baidu.com/80MWbzKh2wt3n2qy8IqW0jdnxx1xbK",
        vector_traffic: "ss0.bdstatic.com/8aZ1cTe9KgQIm2_p8IuM_a"
    };
    z.cW = {
        TILE_BASE_URLS: ["shangetu0.map.bdimg.com", "shangetu1.map.bdimg.com", "shangetu2.map.bdimg.com", "shangetu3.map.bdimg.com", "shangetu4.map.bdimg.com"],
        TILE_ONLINE_URLS: ["online0.map.bdimg.com", "online1.map.bdimg.com", "online2.map.bdimg.com", "online3.map.bdimg.com", "online4.map.bdimg.com"],
        TIlE_PERSPECT_URLS: ["d0.map.baidu.com", "d1.map.baidu.com", "d2.map.baidu.com", "d3.map.baidu.com"],
        geolocControl: "loc.map.baidu.com",
        TILES_YUN_HOST: ["g0.api.map.baidu.com", "g1.api.map.baidu.com", "g2.api.map.baidu.com", "g3.api.map.baidu.com"],
        traffic: "its.map.baidu.com",
        iw_pano: "pcsv0.map.bdimg.com",
        message: "j.map.baidu.com",
        baidumap: "map.baidu.com",
        wuxian: "wuxian.baidu.com",
        pano: ["pcsv0.map.bdimg.com", "pcsv1.map.bdimg.com", "pcsv2.map.bdimg.com"],
        main_domain_nocdn: {
            baidu: "api.map.baidu.com"
        },
        main_domain_cdn: {
            baidu: ["api0.map.bdimg.com", "api1.map.bdimg.com", "api2.map.bdimg.com"]
        },
        map_click: "mapclick.map.baidu.com",
        vector_traffic: "or.map.bdimg.com"
    };
    z.bZ = {
        "0": {
            proto: "http://",
            domain: z.cW
        },
        1: {
            proto: "https://",
            domain: z.EK
        },
        2: {
            proto: "https://",
            domain: z.EK
        }
    };
    z.Yx = window.HOST_TYPE || "0";
    z.url = z.bZ[z.Yx];
    z.Jo = z.url.proto + z.url.domain.baidumap + "/";
    z.wc = z.url.proto + ("2" == z.Yx ? z.url.domain.main_domain_nocdn.other : z.url.domain.main_domain_nocdn.baidu) + "/";
    z.da = z.url.proto + ("2" == z.Yx ? z.url.domain.main_domain_cdn.other[0] : z.url.domain.main_domain_cdn.baidu[0]) + "/";
    z.cg = function (a, b) {
        var c, d, b = b || "";
        switch (a) {
        case "main_domain_nocdn":
            c = z.wc + b;
            break;
        case "main_domain_cdn":
            c = z.da + b;
            break;
        default:
            d = z.url.domain[a], "[object Array]" == Object.prototype.toString.call(d) ? (c = [], w.Zb.Fb(d, function (a, d) {
                c[d] = z.url.proto + a + "/" + b
            })) : c = z.url.proto + z.url.domain[a] + "/" + b
        }
        return c
    };

    function tb(a) {
        var b = {
            duration: 1E3,
            Lc: 30,
            ao: 0,
            bc: ub.fL,
            Is: s()
        };
        this.Lf = [];
        if (a)
            for (var c in a) b[c] = a[c];
        this.k = b;
        if (Va(b.ao)) {
            var d = this;
            setTimeout(function () {
                d.start()
            }, b.ao)
        } else b.ao != vb && this.start()
    }
    var vb = "INFINITE";
    tb.prototype.start = function () {
        this.au = $a();
        this.jz = this.au + this.k.duration;
        wb(this)
    };
    tb.prototype.add = function (a) {
        this.Lf.push(a)
    };

    function wb(a) {
        var b = $a();
        b >= a.jz ? (Wa(a.k.la) && a.k.la(a.k.bc(1)), Wa(a.k.finish) && a.k.finish(), 0 < a.Lf.length && (b = a.Lf[0], b.Lf = [].concat(a.Lf.slice(1)), b.start())) : (a.Ex = a.k.bc((b - a.au) / a.k.duration), Wa(a.k.la) && a.k.la(a.Ex), a.ME || (a.kr = setTimeout(function () {
            wb(a)
        }, 1E3 / a.k.Lc)))
    }
    tb.prototype.stop = function (a) {
        this.ME = o;
        for (var b = 0; b < this.Lf.length; b++) this.Lf[b].stop(), this.Lf[b] = p;
        this.Lf.length = 0;
        this.kr && (clearTimeout(this.kr), this.kr = p);
        this.k.Is(this.Ex);
        a && (this.jz = this.au, wb(this))
    };
    tb.prototype.cancel = ga(1);
    var ub = {
        fL: function (a) {
            return a
        },
        reverse: function (a) {
            return 1 - a
        },
        mC: function (a) {
            return a * a
        },
        lC: function (a) {
            return Math.pow(a, 3)
        },
        nC: function (a) {
            return -(a * (a - 2))
        },
        GJ: function (a) {
            return Math.pow(a - 1, 3) + 1
        },
        FJ: function (a) {
            return 0.5 > a ? 2 * a * a : -2 * (a - 2) * a - 1
        },
        O_: function (a) {
            return 0.5 > a ? 4 * Math.pow(a, 3) : 4 * Math.pow(a - 1, 3) + 1
        },
        P_: function (a) {
            return (1 - Math.cos(Math.PI * a)) / 2
        }
    };
    ub["ease-in"] = ub.mC;
    ub["ease-out"] = ub.nC;
    var E = {
        dF: 34,
        eF: 21,
        fF: new K(21, 32),
        EN: new K(10, 32),
        DN: new K(24, 36),
        CN: new K(12, 36),
        bF: new K(13, 1),
        ea: z.da + "images/",
        cF: z.da + "images/markers_new.png",
        AN: 24,
        BN: 73,
        qB: {
            "\u5317\u4eac": {
                ux: "bj",
                m: new H(116.403874, 39.914889)
            },
            "\u4e0a\u6d77": {
                ux: "sh",
                m: new H(121.487899, 31.249162)
            },
            "\u6df1\u5733": {
                ux: "sz",
                m: new H(114.025974, 22.546054)
            },
            "\u5e7f\u5dde": {
                ux: "gz",
                m: new H(113.30765, 23.120049)
            }
        },
        fontFamily: "arial,sans-serif"
    };
    w.S.Ig ? (w.extend(E, {
        vJ: "url(" + E.ea + "ruler.cur),crosshair",
        Kb: "-moz-grab",
        ld: "-moz-grabbing"
    }), w.platform.YK && (E.fontFamily = "arial,simsun,sans-serif")) : w.S.$I || w.S.rM ? w.extend(E, {
        vJ: "url(" + E.ea + "ruler.cur) 2 6,crosshair",
        Kb: "url(" + E.ea + "openhand.cur) 8 8,default",
        ld: "url(" + E.ea + "closedhand.cur) 8 8,move"
    }) : w.extend(E, {
        vJ: "url(" + E.ea + "ruler.cur),crosshair",
        Kb: "url(" + E.ea + "openhand.cur),default",
        ld: "url(" + E.ea + "closedhand.cur),move"
    });

    function xb(a, b) {
        var c = a.style;
        c.left = b[0] + "px";
        c.top = b[1] + "px"
    }

    function yb(a) {
        0 < w.S.ba ? a.unselectable = "on" : a.style.MozUserSelect = "none"
    }

    function zb(a) {
        return a && a.parentNode && 11 != a.parentNode.nodeType
    }

    function Ab(a, b) {
        w.B.Tw(a, "beforeEnd", b);
        return a.lastChild
    }

    function Bb(a) {
        for (var b = {
                left: 0,
                top: 0
            }; a && a.offsetParent;) b.left += a.offsetLeft, b.top += a.offsetTop, a = a.offsetParent;
        return b
    }

    function oa(a) {
        a = window.event || a;
        a.stopPropagation ? a.stopPropagation() : a.cancelBubble = o
    }

    function Cb(a) {
        a = window.event || a;
        a.preventDefault ? a.preventDefault() : a.returnValue = q;
        return q
    }

    function pa(a) {
        oa(a);
        return Cb(a)
    }

    function Db() {
        var a = document.documentElement,
            b = document.body;
        return a && (a.scrollTop || a.scrollLeft) ? [a.scrollTop, a.scrollLeft] : b ? [b.scrollTop, b.scrollLeft] : [0, 0]
    }

    function Eb(a, b) {
        if (a && b) return Math.round(Math.sqrt(Math.pow(a.x - b.x, 2) + Math.pow(a.y - b.y, 2)))
    }

    function Fb(a, b) {
        var c = [],
            b = b || function (a) {
                return a
            },
            d;
        for (d in a) c.push(d + "=" + b(a[d]));
        return c.join("&")
    }

    function J(a, b, c) {
        var d = document.createElement(a);
        c && (d = document.createElementNS(c, a));
        return w.B.yE(d, b || {})
    }

    function Ua(a) {
        if (a.currentStyle) return a.currentStyle;
        if (a.ownerDocument && a.ownerDocument.defaultView) return a.ownerDocument.defaultView.getComputedStyle(a, p)
    }

    function Wa(a) {
        return "function" == typeof a
    }

    function Va(a) {
        return "number" == typeof a
    }

    function Ya(a) {
        return "string" == typeof a
    }

    function Gb(a) {
        return "undefined" != typeof a
    }

    function Hb(a) {
        return "object" == typeof a
    }
    var Ib = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";

    function Jb(a) {
        var b = "",
            c, d, e = "",
            f, g = "",
            i = 0;
        f = /[^A-Za-z0-9\+\/\=]/g;
        if (!a || f.exec(a)) return a;
        a = a.replace(/[^A-Za-z0-9\+\/\=]/g, "");
        do c = Ib.indexOf(a.charAt(i++)), d = Ib.indexOf(a.charAt(i++)), f = Ib.indexOf(a.charAt(i++)), g = Ib.indexOf(a.charAt(i++)), c = c << 2 | d >> 4, d = (d & 15) << 4 | f >> 2, e = (f & 3) << 6 | g, b += String.fromCharCode(c), 64 != f && (b += String.fromCharCode(d)), 64 != g && (b += String.fromCharCode(e)); while (i < a.length);
        return b
    }
    var L = w.lang.jy;

    function G() {
        return !(!w.platform.AD && !w.platform.rW && !w.platform.ek)
    }

    function Ta() {
        return !(!w.platform.YK && !w.platform.QK && !w.platform.xW)
    }

    function $a() {
        return (new Date).getTime()
    }

    function Kb() {
        var a = document.body.appendChild(J("div"));
        a.innerHTML = '<v:shape id="vml_tester1" adj="1" />';
        var b = a.firstChild;
        if (!b.style) return q;
        b.style.behavior = "url(#default#VML)";
        b = b ? "object" == typeof b.adj : o;
        a.parentNode.removeChild(a);
        return b
    }

    function Lb() {
        return !!document.implementation.hasFeature("http://www.w3.org/TR/SVG11/feature#Shape", "1.1")
    }

    function Mb() {
        return !!J("canvas").getContext
    }

    function Nb(a) {
        return a * Math.PI / 180
    }
    z.GW = function () {
        var a = o,
            b = o,
            c = o,
            d = o,
            e = 0,
            f = 0,
            g = 0,
            i = 0;
        return {
            fP: function () {
                e += 1;
                a && (a = q, setTimeout(function () {
                    Pa(5054, {
                        pic: e
                    });
                    a = o;
                    e = 0
                }, 1E4))
            },
            HZ: function () {
                f += 1;
                b && (b = q, setTimeout(function () {
                    Pa(5055, {
                        move: f
                    });
                    b = o;
                    f = 0
                }, 1E4))
            },
            JZ: function () {
                g += 1;
                c && (c = q, setTimeout(function () {
                    Pa(5056, {
                        zoom: g
                    });
                    c = o;
                    g = 0
                }, 1E4))
            },
            IZ: function (a) {
                i += a;
                d && (d = q, setTimeout(function () {
                    Pa(5057, {
                        tile: i
                    });
                    d = o;
                    i = 0
                }, 5E3))
            }
        }
    }();
    var Za;
    (function () {
        function a(a) {
            this.jT = a;
            this.timing = {};
            this.start = +new Date
        }

        function b(a, b) {
            if (a.length === +a.length)
                for (var c = 0, d = a.length; c < d && b.call(j, c, a[c], a) !== q; c++);
            else
                for (c in a)
                    if (a.hasOwnProperty(c) && b.call(j, c, a[c], a) === q) break
        }
        var c = [],
            d = {
                push: function (a) {
                    c.push(a);
                    if (window.localStorage && window.JSON) try {
                        localStorage.setItem("WPO_NR", JSON.stringify(c))
                    } catch (b) {}
                },
                get: function (a) {
                    var b = [];
                    if (window.localStorage) try {
                        a && localStorage.removeItem("WPO_NR")
                    } catch (d) {}
                    b = c;
                    a && (c = []);
                    return b
                }
            },
            e, f, g, i, k = {};
        (!window.localStorage || !window.JSON) && document.attachEvent && window.attachEvent("onbeforeunload", function () {
            l.send()
        });
        var l = {
            send: function (a) {
                var c = [],
                    e = [],
                    f = a || d.get(o),
                    g;
                0 < f.length && (b(f, function (d, e) {
                    var f = [];
                    b(e.timing, function (a, b) {
                        f.push('"' + a + '":' + b)
                    });
                    c.push('{"t":{' + f.join(",") + '},"a":' + e.jT + "}");
                    !g && (a && e.start) && (g = e.start)
                }), b(k, function (a, b) {
                    e.push(a + "=" + b)
                }), e.push("d=[" + c.join(",") + "]"), g ? e.push("_st=" + g) : e.push("_t=" + +new Date), f = new Image, f.src = "http://static.tieba.baidu.com/tb/pms/img/st.gif?" + e.join("&"), window["___pms_img_" + 1 * new Date] = f)
            }
        };
        a.prototype = {
            $b: function (a, b) {
                this.timing[a] = 0 <= b ? b : new Date - this.start
            },
            nt: function () {
                this.start = +new Date
            },
            dN: function () {
                this.$b("tt")
            },
            Zx: function () {
                this.$b("vt")
            },
            vm: function () {
                f && (d.push(this), d.get().length >= g && l.send())
            },
            error: s()
        };
        Za = {
            li: {
                rD: function (a) {
                    var b = navigator.C_ || navigator.Z0 || navigator.i2 || {
                        type: 0
                    };
                    f = Math.random() <= (a.EX || 0.01);
                    g = a.max || 5;
                    i = a.Y0 || b.type;
                    k = {
                        p: a.qX,
                        mnt: i,
                        b: 50
                    };
                    window.localStorage && (window.JSON && window.addEventListener) && (e = d.get(o), window.addEventListener("load", function () {
                        l.send(e)
                    }, q))
                },
                Qj: function (b) {
                    return new a(b)
                }
            }
        }
    })();
    Za.li.rD({
        qX: 18,
        EX: 0.1,
        max: 1
    });
    z.zp = {
        rF: "#83a1ff",
        Bp: "#808080"
    };

    function Ob(a, b, c) {
        b.lm || (b.lm = [], b.handle = {});
        b.lm.push({
            filter: c,
            Nl: a
        });
        b.addEventListener || (b.addEventListener = function (a, c) {
            b.attachEvent("on" + a, c)
        });
        b.handle.click || (b.addEventListener("click", function (a) {
            for (var c = a.target || a.srcElement; c != b;) {
                Pb(b.lm, function (b, g) {
                    RegExp(g.filter).test(c.getAttribute("filter")) && g.Nl.call(c, a, c.getAttribute("filter"))
                });
                c = c.parentNode
            }
        }, q), b.handle.click = o)
    }

    function Pb(a, b) {
        for (var c = 0, d = a.length; c < d; c++) b(c, a[c])
    };

    function Qb(a, b) {
        if (b) {
            var c = (1E5 * Math.random()).toFixed(0);
            z._rd["_cbk" + c] = function (a) {
                b && b(a);
                delete z._rd["_cbk" + c]
            };
            a += "&callback=BMap._rd._cbk" + c
        }
        var d = J("script", {
            type: "text/javascript"
        });
        d.charset = "utf-8";
        d.src = a;
        d.addEventListener ? d.addEventListener("load", function (a) {
            a = a.target;
            a.parentNode.removeChild(a)
        }, q) : d.attachEvent && d.attachEvent("onreadystatechange", function () {
            var a = window.event.srcElement;
            a && ("loaded" == a.readyState || "complete" == a.readyState) && a.parentNode.removeChild(a)
        });
        setTimeout(function () {
            document.getElementsByTagName("head")[0].appendChild(d);
            d = p
        }, 1)
    };
    var Rb = {
        map: "xn4rti",
        common: "ehfxcq",
        style: "jshvp1",
        tile: "wqzmwn",
        vectordrawlib: "2yoosd",
        newvectordrawlib: "xqtctp",
        groundoverlay: "3jclsc",
        pointcollection: "vis3oz",
        marker: "aamg0m",
        symbol: "uqqbbf",
        canvablepath: "farymn",
        vmlcontext: "npufdi",
        markeranimation: "tpqqc5",
        poly: "44f0gd",
        draw: "i023rn",
        drawbysvg: "qzkv5p",
        drawbyvml: "keozi0",
        drawbycanvas: "1jd3ji",
        infowindow: "253uw3",
        oppc: "qcwbbm",
        opmb: "cvq5t4",
        menu: "pf0tlk",
        control: "mfcq0d",
        navictrl: "ryfuo1",
        geoctrl: "cfk1m2",
        copyrightctrl: "e0b5tg",
        scommon: "mt3ime",
        local: "pxr1mg",
        route: "eft2t0",
        othersearch: "fn0y4d",
        mapclick: "5qb0qt",
        buslinesearch: "ufg1wk",
        hotspot: "nopjxz",
        autocomplete: "o52cbr",
        coordtrans: "gqqeoj",
        coordtransutils: "czavb4",
        clayer: "53fhyu",
        pservice: "hla1vc",
        pcommon: "tjownc",
        panorama: "dncdoi",
        panoramaflash: "oymok3",
        vector: "gnqrjg"
    };
    w.Sx = function () {
        function a(a) {
            return d && !!c[b + a + "_" + Rb[a]]
        }
        var b = "BMap_",
            c = window.localStorage,
            d = "localStorage" in window && c !== p && c !== j;
        return {
            tW: d,
            set: function (a, f) {
                if (d) {
                    for (var g = b + a + "_", i = c.length, k; i--;) k = c.key(i), -1 < k.indexOf(g) && c.removeItem(k);
                    try {
                        c.setItem(b + a + "_" + Rb[a], f)
                    } catch (l) {
                        c.clear()
                    }
                }
            },
            get: function (e) {
                return d && a(e) ? c.getItem(b + e + "_" + Rb[e]) : q
            },
            YI: a
        }
    }();

    function I() {}
    w.object.extend(I, {
        nj: {
            tF: -1,
            jO: 0,
            up: 1
        },
        eK: function () {
            var a = "drawbysvg",
                b = "canvablepath",
                c = z.uI ? "newvectordrawlib" : "vectordrawlib";
            G() && Mb() ? a = "drawbycanvas" : Lb() ? a = "drawbysvg" : Kb() ? (a = "drawbyvml", b = "vmlcontext") : Mb() && (a = "drawbycanvas");
            return {
                tile: [c],
                control: [],
                marker: ["symbol"],
                symbol: ["canvablepath", "common"],
                canvablepath: "canvablepath" === b ? [] : [b],
                vmlcontext: [],
                style: [],
                poly: ["marker", a],
                drawbysvg: ["draw"],
                drawbyvml: ["draw"],
                drawbycanvas: ["draw"],
                infowindow: ["common", "marker"],
                menu: [],
                oppc: [],
                opmb: [],
                scommon: [],
                local: ["scommon"],
                route: ["scommon"],
                othersearch: ["scommon"],
                autocomplete: ["scommon"],
                mapclick: ["scommon"],
                buslinesearch: ["route"],
                hotspot: [],
                coordtransutils: ["coordtrans"],
                clayer: ["tile"],
                pservice: [],
                pcommon: ["style", "pservice"],
                panorama: ["pcommon"],
                panoramaflash: ["pcommon"]
            }
        },
        o1: {},
        lF: {
            yO: z.da + "getmodules?v=2.0&t=20140707",
            OS: 5E3
        },
        OB: q,
        yd: {
            Sk: {},
            Um: [],
            iv: []
        },
        load: function (a, b, c) {
            var d = this.Va(a);
            if (d.jd == this.nj.up) c && b();
            else {
                if (d.jd == this.nj.tF) {
                    this.eJ(a);
                    this.dM(a);
                    var e = this;
                    e.OB == q && (e.OB = o, setTimeout(function () {
                        for (var a = [], b = 0, c = e.yd.Um.length; b < c; b++) {
                            var d = e.yd.Um[b],
                                l = "";
                            ja.Sx.YI(d) ? l = ja.Sx.get(d) : (l = "", a.push(d + "_" + Rb[d]));
                            e.yd.iv.push({
                                zL: d,
                                TD: l
                            })
                        }
                        e.OB = q;
                        e.yd.Um.length = 0;
                        0 == a.length ? e.MJ() : Qb(e.lF.yO + "&mod=" + a.join(","))
                    }, 1));
                    d.jd = this.nj.jO
                }
                d.eu.push(b)
            }
        },
        eJ: function (a) {
            if (a && this.eK()[a])
                for (var a = this.eK()[a], b = 0; b < a.length; b++) this.eJ(a[b]), this.yd.Sk[a[b]] || this.dM(a[b])
        },
        dM: function (a) {
            for (var b = 0; b < this.yd.Um.length; b++)
                if (this.yd.Um[b] == a) return;
            this.yd.Um.push(a)
        },
        DX: function (a, b) {
            var c = this.Va(a);
            try {
                eval(b)
            } catch (d) {
                return
            }
            c.jd = this.nj.up;
            for (var e = 0, f = c.eu.length; e < f; e++) c.eu[e]();
            c.eu.length = 0
        },
        YI: function (a, b) {
            var c = this;
            c.timeout = setTimeout(function () {
                c.yd.Sk[a].jd != c.nj.up ? (c.remove(a), c.load(a, b)) : clearTimeout(c.timeout)
            }, c.lF.OS)
        },
        Va: function (a) {
            this.yd.Sk[a] || (this.yd.Sk[a] = {}, this.yd.Sk[a].jd = this.nj.tF, this.yd.Sk[a].eu = []);
            return this.yd.Sk[a]
        },
        remove: function (a) {
            delete this.Va(a)
        },
        FT: function (a, b) {
            for (var c = this.yd.iv, d = o, e = 0, f = c.length; e < f; e++) "" == c[e].TD && (c[e].zL == a ? c[e].TD = b : d = q);
            d && this.MJ()
        },
        MJ: function () {
            for (var a = this.yd.iv, b = 0, c = a.length; b < c; b++) this.DX(a[b].zL, a[b].TD);
            this.yd.iv.length = 0
        }
    });

    function P(a, b) {
        this.x = a || 0;
        this.y = b || 0;
        this.x = this.x;
        this.y = this.y
    }
    P.prototype.$a = function (a) {
        return a && a.x == this.x && a.y == this.y
    };

    function K(a, b) {
        this.width = a || 0;
        this.height = b || 0
    }
    K.prototype.$a = function (a) {
        return a && this.width == a.width && this.height == a.height
    };

    function hb(a, b) {
        a && (this.xb = a, this.Q = "spot" + hb.Q++, b = b || {}, this.zg = b.text || "", this.Pu = b.offsets ? b.offsets.slice(0) : [5, 5, 5, 5], this.nI = b.userData || p, this.xh = b.minZoom || p, this.kf = b.maxZoom || p)
    }
    hb.Q = 0;
    w.extend(hb.prototype, {
        fa: function (a) {
            this.xh == p && (this.xh = a.D.Tb);
            this.kf == p && (this.kf = a.D.Mb)
        },
        ha: function (a) {
            a instanceof H && (this.xb = a)
        },
        V: u("xb"),
        at: ba("zg"),
        gD: u("zg"),
        setUserData: ba("nI"),
        getUserData: u("nI")
    });

    function Sb() {
        this.C = p;
        this.yb = "control";
        this.Da = this.SI = o
    }
    w.lang.ja(Sb, w.lang.ra, "Control");
    w.extend(Sb.prototype, {
        initialize: function (a) {
            this.C = a;
            if (this.A) return a.Ia.appendChild(this.A), this.A
        },
        Le: function (a) {
            !this.A && (this.initialize && Wa(this.initialize)) && (this.A = this.initialize(a));
            this.k = this.k || {
                $g: q
            };
            this.HA();
            this.bv();
            this.A && (this.A.zq = this)
        },
        HA: function () {
            var a = this.A;
            if (a) {
                var b = a.style;
                b.position = "absolute";
                b.zIndex = this.Hy || "10";
                b.MozUserSelect = "none";
                b.WebkitTextSizeAdjust = "none";
                this.k.$g || w.B.Ya(a, "BMap_noprint");
                G() || w.F(a, "contextmenu", pa)
            }
        },
        remove: function () {
            this.C = p;
            this.A && (this.A.parentNode && this.A.parentNode.removeChild(this.A), this.A = this.A.zq = p)
        },
        qa: function () {
            this.A = Ab(this.C.Ia, "<div unselectable='on'></div>");
            this.Da == q && w.B.J(this.A);
            return this.A
        },
        bv: function () {
            this.lc(this.k.anchor)
        },
        lc: function (a) {
            if (this.m_ || !Va(a) || isNaN(a) || a < Tb || 3 < a) a = this.defaultAnchor;
            this.k = this.k || {
                $g: q
            };
            this.k.pa = this.k.pa || this.defaultOffset;
            var b = this.k.anchor;
            this.k.anchor = a;
            if (this.A) {
                var c = this.A,
                    d = this.k.pa.width,
                    e = this.k.pa.height;
                c.style.left = c.style.top = c.style.right = c.style.bottom = "auto";
                switch (a) {
                case Tb:
                    c.style.top = e + "px";
                    c.style.left = d + "px";
                    break;
                case Ub:
                    c.style.top = e + "px";
                    c.style.right = d + "px";
                    break;
                case Vb:
                    c.style.bottom = e + "px";
                    c.style.left = d + "px";
                    break;
                case 3:
                    c.style.bottom = e + "px", c.style.right = d + "px"
                }
                c = ["TL", "TR", "BL", "BR"];
                w.B.Xb(this.A, "anchor" + c[b]);
                w.B.Ya(this.A, "anchor" + c[a])
            }
        },
        KC: function () {
            return this.k.anchor
        },
        he: function (a) {
            a instanceof K && (this.k = this.k || {
                $g: q
            }, this.k.pa = new K(a.width, a.height), this.A && this.lc(this.k.anchor))
        },
        Af: function () {
            return this.k.pa
        },
        nd: u("A"),
        show: function () {
            this.Da != o && (this.Da = o, this.A && w.B.show(this.A))
        },
        J: function () {
            this.Da != q && (this.Da = q, this.A && w.B.J(this.A))
        },
        isPrintable: function () {
            return !!this.k.$g
        },
        Rg: function () {
            return !this.A && !this.C ? q : !!this.Da
        }
    });
    var Tb = 0,
        Ub = 1,
        Vb = 2;

    function ib(a) {
        Sb.call(this);
        a = a || {};
        this.k = {
            $g: q,
            IE: a.showZoomInfo || o,
            anchor: a.anchor,
            pa: a.offset,
            type: a.type,
            CU: a.enableGeolocation || q
        };
        this.defaultAnchor = G() ? 3 : Tb;
        this.defaultOffset = new K(10, 10);
        this.lc(a.anchor);
        this.Em(a.type);
        this.cf()
    }
    w.lang.ja(ib, Sb, "NavigationControl");
    w.extend(ib.prototype, {
        initialize: function (a) {
            this.C = a;
            return this.A
        },
        Em: function (a) {
            this.k.type = Va(a) && 0 <= a && 3 >= a ? a : 0
        },
        zo: function () {
            return this.k.type
        },
        cf: function () {
            var a = this;
            I.load("navictrl", function () {
                a.pg()
            })
        }
    });

    function Wb(a) {
        Sb.call(this);
        a = a || {};
        this.k = {
            anchor: a.anchor || Vb,
            pa: a.offset || new K(10, 30),
            I1: a.showAddressBar || q,
            R_: a.enableAutoLocation || q,
            mL: a.locationIcon || p
        };
        var b = this;
        this.Hy = 1200;
        b.dZ = [];
        this.Yd = [];
        I.load("geoctrl", function () {
            (function d() {
                if (0 !== b.Yd.length) {
                    var a = b.Yd.shift();
                    b[a.method].apply(b, a.arguments);
                    d()
                }
            })();
            b.xO()
        });
        Pa(Ja)
    }
    w.lang.ja(Wb, Sb, "GeolocationControl");
    w.extend(Wb.prototype, {
        location: function () {
            this.Yd.push({
                method: "location",
                arguments: arguments
            })
        },
        getAddressComponent: da(p)
    });

    function Xb(a) {
        Sb.call(this);
        a = a || {};
        this.k = {
            $g: q,
            anchor: a.anchor,
            pa: a.offset
        };
        this.Qb = [];
        this.defaultAnchor = Vb;
        this.defaultOffset = new K(5, 2);
        this.lc(a.anchor);
        this.SI = q;
        this.cf()
    }
    w.lang.ja(Xb, Sb, "CopyrightControl");
    w.object.extend(Xb.prototype, {
        initialize: function (a) {
            this.C = a;
            return this.A
        },
        Ev: function (a) {
            if (a && Va(a.id) && !isNaN(a.id)) {
                var b = {
                        bounds: p,
                        content: ""
                    },
                    c;
                for (c in a) b[c] = a[c];
                if (a = this.Ql(a.id))
                    for (var d in b) a[d] = b[d];
                else this.Qb.push(b)
            }
        },
        Ql: function (a) {
            for (var b = 0, c = this.Qb.length; b < c; b++)
                if (this.Qb[b].id == a) return this.Qb[b]
        },
        RC: u("Qb"),
        lE: function (a) {
            for (var b = 0, c = this.Qb.length; b < c; b++) this.Qb[b].id == a && (r = this.Qb.splice(b, 1), b--, c = this.Qb.length)
        },
        cf: function () {
            var a = this;
            I.load("copyrightctrl", function () {
                a.pg()
            })
        }
    });

    function lb(a) {
        Sb.call(this);
        a = a || {};
        this.k = {
            $g: q,
            size: a.size || new K(150, 150),
            padding: 5,
            Ja: a.isOpen === o ? o : q,
            tZ: 4,
            pa: a.offset,
            anchor: a.anchor
        };
        this.defaultAnchor = 3;
        this.defaultOffset = new K(0, 0);
        this.Pp = this.Qp = 13;
        this.lc(a.anchor);
        this.sd(this.k.size);
        this.cf()
    }
    w.lang.ja(lb, Sb, "OverviewMapControl");
    w.extend(lb.prototype, {
        initialize: function (a) {
            this.C = a;
            return this.A
        },
        lc: function (a) {
            Sb.prototype.lc.call(this, a)
        },
        $d: function () {
            this.$d.Dn = o;
            this.k.Ja = !this.k.Ja;
            this.A || (this.$d.Dn = q)
        },
        sd: function (a) {
            a instanceof K || (a = new K(150, 150));
            a.width = 0 < a.width ? a.width : 150;
            a.height = 0 < a.height ? a.height : 150;
            this.k.size = a
        },
        Lb: function () {
            return this.k.size
        },
        Ja: function () {
            return this.k.Ja
        },
        cf: function () {
            var a = this;
            I.load("control", function () {
                a.pg()
            })
        }
    });

    function jb(a) {
        Sb.call(this);
        a = a || {};
        this.k = {
            $g: q,
            color: "black",
            Qc: "metric",
            pa: a.offset
        };
        this.defaultAnchor = Vb;
        this.defaultOffset = new K(81, 18);
        this.lc(a.anchor);
        this.Gh = {
            metric: {
                name: "metric",
                gJ: 1,
                JK: 1E3,
                hN: "\u7c73",
                iN: "\u516c\u91cc"
            },
            us: {
                name: "us",
                gJ: 3.2808,
                JK: 5280,
                hN: "\u82f1\u5c3a",
                iN: "\u82f1\u91cc"
            }
        };
        this.Gh[this.k.Qc] || (this.k.Qc = "metric");
        this.MH = p;
        this.mH = {};
        this.cf()
    }
    w.lang.ja(jb, Sb, "ScaleControl");
    w.object.extend(jb.prototype, {
        initialize: function (a) {
            this.C = a;
            return this.A
        },
        mk: function (a) {
            this.k.color = a + ""
        },
        c0: function () {
            return this.k.color
        },
        FE: function (a) {
            this.k.Qc = this.Gh[a] && this.Gh[a].name || this.k.Qc
        },
        RV: function () {
            return this.k.Qc
        },
        cf: function () {
            var a = this;
            I.load("control", function () {
                a.pg()
            })
        }
    });
    var Yb = 0;

    function mb(a) {
        Sb.call(this);
        a = a || {};
        this.defaultAnchor = Ub;
        this.defaultOffset = new K(10, 10);
        this.k = {
            $g: q,
            Ug: [La, Xa, Qa, Oa],
            gU: ["B_DIMENSIONAL_MAP", "B_SATELLITE_MAP", "B_NORMAL_MAP"],
            type: a.type || Yb,
            pa: a.offset || this.defaultOffset,
            GU: o
        };
        this.lc(a.anchor);
        "[object Array]" == Object.prototype.toString.call(a.mapTypes) && (this.k.Ug = a.mapTypes.slice(0));
        this.cf()
    }
    w.lang.ja(mb, Sb, "MapTypeControl");
    w.object.extend(mb.prototype, {
        initialize: function (a) {
            this.C = a;
            return this.A
        },
        Tx: function (a) {
            this.C.tn = a
        },
        cf: function () {
            var a = this;
            I.load("control", function () {
                a.pg()
            }, o)
        }
    });

    function Zb(a) {
        Sb.call(this);
        a = a || {};
        this.k = {
            $g: q,
            pa: a.offset,
            anchor: a.anchor
        };
        this.xi = q;
        this.mv = p;
        this.vH = new $b({
            yf: "api"
        });
        this.wH = new ac(p, {
            yf: "api"
        });
        this.defaultAnchor = Ub;
        this.defaultOffset = new K(10, 10);
        this.lc(a.anchor);
        this.cf();
        Pa(wa)
    }
    w.lang.ja(Zb, Sb, "PanoramaControl");
    w.extend(Zb.prototype, {
        initialize: function (a) {
            this.C = a;
            return this.A
        },
        cf: function () {
            var a = this;
            I.load("control", function () {
                a.pg()
            })
        }
    });

    function bc(a) {
        w.lang.ra.call(this);
        this.k = {
            Ia: p,
            cursor: "default"
        };
        this.k = w.extend(this.k, a);
        this.yb = "contextmenu";
        this.C = p;
        this.na = [];
        this.of = [];
        this.ne = [];
        this.cw = this.Cr = p;
        this.vh = q;
        var b = this;
        I.load("menu", function () {
            b.rb()
        })
    }
    w.lang.ja(bc, w.lang.ra, "ContextMenu");
    w.object.extend(bc.prototype, {
        fa: function (a, b) {
            this.C = a;
            this.Xk = b || p
        },
        remove: function () {
            this.C = this.Xk = p
        },
        Gv: function (a) {
            if (a && !("menuitem" != a.yb || "" == a.zg || 0 >= a.Hi)) {
                for (var b = 0, c = this.na.length; b < c; b++)
                    if (this.na[b] === a) return;
                this.na.push(a);
                this.of.push(a)
            }
        },
        removeItem: function (a) {
            if (a && "menuitem" == a.yb) {
                for (var b = 0, c = this.na.length; b < c; b++) this.na[b] === a && (this.na[b].remove(), this.na.splice(b, 1), c--);
                b = 0;
                for (c = this.of.length; b < c; b++) this.of[b] === a && (this.of[b].remove(), this.of.splice(b, 1), c--)
            }
        },
        aB: function () {
            this.na.push({
                yb: "divider",
                tj: this.ne.length
            });
            this.ne.push({
                B: p
            })
        },
        nE: function (a) {
            if (this.ne[a]) {
                for (var b = 0, c = this.na.length; b < c; b++) this.na[b] && ("divider" == this.na[b].yb && this.na[b].tj == a) && (this.na.splice(b, 1), c--), this.na[b] && ("divider" == this.na[b].yb && this.na[b].tj > a) && this.na[b].tj--;
                this.ne.splice(a, 1)
            }
        },
        nd: u("A"),
        show: function () {
            this.vh != o && (this.vh = o)
        },
        J: function () {
            this.vh != q && (this.vh = q)
        },
        TX: function (a) {
            a && (this.k.cursor = a)
        },
        getItem: function (a) {
            return this.of[a]
        }
    });
    var cc = E.ea + "menu_zoom_in.png",
        dc = E.ea + "menu_zoom_out.png";

    function ec(a, b, c) {
        if (a && Wa(b)) {
            w.lang.ra.call(this);
            this.k = {
                width: 100,
                id: "",
                bm: ""
            };
            c = c || {};
            this.k.width = 1 * c.width ? c.width : 100;
            this.k.id = c.id ? c.id : "";
            this.k.bm = c.iconUrl ? c.iconUrl : "";
            this.zg = a + "";
            this.Ky = b;
            this.C = p;
            this.yb = "menuitem";
            this.ir = this.Du = this.A = this.lh = p;
            this.ph = o;
            var d = this;
            I.load("menu", function () {
                d.rb()
            })
        }
    }
    w.lang.ja(ec, w.lang.ra, "MenuItem");
    w.object.extend(ec.prototype, {
        fa: function (a, b) {
            this.C = a;
            this.lh = b
        },
        remove: function () {
            this.C = this.lh = p
        },
        at: function (a) {
            a && (this.zg = a + "")
        },
        Ob: function (a) {
            a && (this.k.bm = a)
        },
        nd: u("A"),
        enable: function () {
            this.ph = o
        },
        disable: function () {
            this.ph = q
        }
    });

    function eb(a, b) {
        a && !b && (b = a);
        this.re = this.qe = this.we = this.ve = this.ll = this.Vk = p;
        a && (this.ll = new H(a.lng, a.lat), this.Vk = new H(b.lng, b.lat), this.we = a.lng, this.ve = a.lat, this.re = b.lng, this.qe = b.lat)
    }
    w.object.extend(eb.prototype, {
        ej: function () {
            return !this.ll || !this.Vk
        },
        $a: function (a) {
            return !(a instanceof eb) || this.ej() ? q : this.Ce().$a(a.Ce()) && this.zf().$a(a.zf())
        },
        Ce: u("ll"),
        zf: u("Vk"),
        TT: function (a) {
            return !(a instanceof eb) || this.ej() || a.ej() ? q : a.we > this.we && a.re < this.re && a.ve > this.ve && a.qe < this.qe
        },
        za: function () {
            return this.ej() ? p : new H((this.we + this.re) / 2, (this.ve + this.qe) / 2)
        },
        ts: function (a) {
            if (!(a instanceof eb) || Math.max(a.we, a.re) < Math.min(this.we, this.re) || Math.min(a.we, a.re) > Math.max(this.we, this.re) || Math.max(a.ve, a.qe) < Math.min(this.ve, this.qe) || Math.min(a.ve, a.qe) > Math.max(this.ve, this.qe)) return p;
            var b = Math.max(this.we, a.we),
                c = Math.min(this.re, a.re),
                d = Math.max(this.ve, a.ve),
                a = Math.min(this.qe, a.qe);
            return new eb(new H(b, d), new H(c, a))
        },
        xr: function (a) {
            return !(a instanceof H) || this.ej() ? q : a.lng >= this.we && a.lng <= this.re && a.lat >= this.ve && a.lat <= this.qe
        },
        extend: function (a) {
            if (a instanceof H) {
                var b = a.lng,
                    a = a.lat;
                this.ll || (this.ll = new H(0, 0));
                this.Vk || (this.Vk = new H(0, 0));
                if (!this.we || this.we > b) this.ll.lng = this.we = b;
                if (!this.re || this.re < b) this.Vk.lng = this.re = b;
                if (!this.ve || this.ve > a) this.ll.lat = this.ve = a;
                if (!this.qe || this.qe < a) this.Vk.lat = this.qe = a
            }
        },
        QE: function () {
            return this.ej() ? new H(0, 0) : new H(Math.abs(this.re - this.we), Math.abs(this.qe - this.ve))
        }
    });

    function H(a, b) {
        isNaN(a) && (a = Jb(a), a = isNaN(a) ? 0 : a);
        Ya(a) && (a = parseFloat(a));
        isNaN(b) && (b = Jb(b), b = isNaN(b) ? 0 : b);
        Ya(b) && (b = parseFloat(b));
        this.lng = a;
        this.lat = b
    }
    H.PK = function (a) {
        return a && 180 >= a.lng && -180 <= a.lng && 74 >= a.lat && -74 <= a.lat
    };
    H.prototype.$a = function (a) {
        return a && this.lat == a.lat && this.lng == a.lng
    };

    function fc() {}
    fc.prototype.Sg = function () {
        aa("lngLatToPoint\u65b9\u6cd5\u672a\u5b9e\u73b0")
    };
    fc.prototype.bi = function () {
        aa("pointToLngLat\u65b9\u6cd5\u672a\u5b9e\u73b0")
    };

    function gc() {};
    var db = {
        iJ: function (a, b, c) {
            I.load("coordtransutils", function () {
                db.oT(a, b, c)
            }, o)
        },
        hJ: function (a, b, c) {
            I.load("coordtransutils", function () {
                db.nT(a, b, c)
            }, o)
        }
    };

    function Q() {}
    Q.prototype = new fc;
    w.extend(Q, {
        ON: 6370996.81,
        xF: [1.289059486E7, 8362377.87, 5591021, 3481989.83, 1678043.12, 0],
        Pt: [75, 60, 45, 30, 15, 0],
        UN: [[1.410526172116255E-8, 8.98305509648872E-6, -1.9939833816331, 200.9824383106796, -187.2403703815547, 91.6087516669843, -23.38765649603339, 2.57121317296198, -0.03801003308653, 1.73379812E7], [-7.435856389565537E-9, 8.983055097726239E-6, -0.78625201886289, 96.32687599759846, -1.85204757529826, -59.36935905485877, 47.40033549296737, -16.50741931063887, 2.28786674699375, 1.026014486E7], [-3.030883460898826E-8, 8.98305509983578E-6, 0.30071316287616, 59.74293618442277, 7.357984074871, -25.38371002664745, 13.45380521110908, -3.29883767235584, 0.32710905363475, 6856817.37], [-1.981981304930552E-8, 8.983055099779535E-6, 0.03278182852591, 40.31678527705744, 0.65659298677277, -4.44255534477492, 0.85341911805263, 0.12923347998204, -0.04625736007561, 4482777.06], [3.09191371068437E-9, 8.983055096812155E-6, 6.995724062E-5, 23.10934304144901, -2.3663490511E-4, -0.6321817810242, -0.00663494467273, 0.03430082397953, -0.00466043876332, 2555164.4], [2.890871144776878E-9, 8.983055095805407E-6, -3.068298E-8, 7.47137025468032, -3.53937994E-6, -0.02145144861037, -1.234426596E-5, 1.0322952773E-4, -3.23890364E-6, 826088.5]],
        uF: [[-0.0015702102444, 111320.7020616939, 1704480524535203, -10338987376042340, 26112667856603880, -35149669176653700, 26595700718403920, -10725012454188240, 1800819912950474, 82.5], [8.277824516172526E-4, 111320.7020463578, 6.477955746671607E8, -4.082003173641316E9, 1.077490566351142E10, -1.517187553151559E10, 1.205306533862167E10, -5.124939663577472E9, 9.133119359512032E8, 67.5], [0.00337398766765, 111320.7020202162, 4481351.045890365, -2.339375119931662E7, 7.968221547186455E7, -1.159649932797253E8, 9.723671115602145E7, -4.366194633752821E7, 8477230.501135234, 52.5], [0.00220636496208, 111320.7020209128, 51751.86112841131, 3796837.749470245, 992013.7397791013, -1221952.21711287, 1340652.697009075, -620943.6990984312, 144416.9293806241, 37.5], [-3.441963504368392E-4, 111320.7020576856, 278.2353980772752, 2485758.690035394, 6070.750963243378, 54821.18345352118, 9540.606633304236, -2710.55326746645, 1405.483844121726, 22.5], [-3.218135878613132E-4, 111320.7020701615, 0.00369383431289, 823725.6402795718, 0.46104986909093, 2351.343141331292, 1.58060784298199, 8.77738589078284, 0.37238884252424, 7.45]],
        h0: function (a, b) {
            if (!a || !b) return 0;
            var c, d, a = this.sb(a);
            if (!a) return 0;
            c = this.uk(a.lng);
            d = this.uk(a.lat);
            b = this.sb(b);
            return !b ? 0 : this.Ue(c, this.uk(b.lng), d, this.uk(b.lat))
        },
        oo: function (a, b) {
            if (!a || !b) return 0;
            a.lng = this.ZC(a.lng, -180, 180);
            a.lat = this.dD(a.lat, -74, 74);
            b.lng = this.ZC(b.lng, -180, 180);
            b.lat = this.dD(b.lat, -74, 74);
            return this.Ue(this.uk(a.lng), this.uk(b.lng), this.uk(a.lat), this.uk(b.lat))
        },
        sb: function (a) {
            if (a === p || a === j) return new H(0, 0);
            var b, c;
            b = new H(Math.abs(a.lng), Math.abs(a.lat));
            for (var d = 0; d < this.xF.length; d++)
                if (b.lat >= this.xF[d]) {
                    c = this.UN[d];
                    break
                }
            a = this.jJ(a, c);
            return a = new H(a.lng.toFixed(6), a.lat.toFixed(6))
        },
        Eb: function (a) {
            if (a === p || a === j || 180 < a.lng || -180 > a.lng || 90 < a.lat || -90 > a.lat) return new H(0, 0);
            var b, c;
            a.lng = this.ZC(a.lng, -180, 180);
            a.lat = this.dD(a.lat, -74, 74);
            b = new H(a.lng, a.lat);
            for (var d = 0; d < this.Pt.length; d++)
                if (b.lat >= this.Pt[d]) {
                    c = this.uF[d];
                    break
                }
            if (!c)
                for (d = this.Pt.length - 1; 0 <= d; d--)
                    if (b.lat <= -this.Pt[d]) {
                        c = this.uF[d];
                        break
                    }
            a = this.jJ(a, c);
            return a = new H(a.lng.toFixed(2), a.lat.toFixed(2))
        },
        jJ: function (a, b) {
            if (a && b) {
                var c = b[0] + b[1] * Math.abs(a.lng),
                    d = Math.abs(a.lat) / b[9],
                    d = b[2] + b[3] * d + b[4] * d * d + b[5] * d * d * d + b[6] * d * d * d * d + b[7] * d * d * d * d * d + b[8] * d * d * d * d * d * d,
                    c = c * (0 > a.lng ? -1 : 1),
                    d = d * (0 > a.lat ? -1 : 1);
                return new H(c, d)
            }
        },
        Ue: function (a, b, c, d) {
            return this.ON * Math.acos(Math.sin(c) * Math.sin(d) + Math.cos(c) * Math.cos(d) * Math.cos(b - a))
        },
        uk: function (a) {
            return Math.PI * a / 180
        },
        Q1: function (a) {
            return 180 * a / Math.PI
        },
        dD: function (a, b, c) {
            b != p && (a = Math.max(a, b));
            c != p && (a = Math.min(a, c));
            return a
        },
        ZC: function (a, b, c) {
            for (; a > c;) a -= c - b;
            for (; a < b;) a += c - b;
            return a
        }
    });
    w.extend(Q.prototype, {
        im: function (a) {
            return Q.Eb(a)
        },
        Sg: function (a) {
            a = Q.Eb(a);
            return new P(a.lng, a.lat)
        },
        Vg: function (a) {
            return Q.sb(a)
        },
        bi: function (a) {
            a = new H(a.x, a.y);
            return Q.sb(a)
        },
        Ub: function (a, b, c, d, e) {
            if (a) return a = this.im(a, e), b = this.gc(b), new P(Math.round((a.lng - c.lng) / b + d.width / 2), Math.round((c.lat - a.lat) / b + d.height / 2))
        },
        nb: function (a, b, c, d, e) {
            if (a) return b = this.gc(b), this.Vg(new H(c.lng + b * (a.x - d.width / 2), c.lat - b * (a.y - d.height / 2)), e)
        },
        gc: function (a) {
            return Math.pow(2, 18 - a)
        }
    });

    function gb() {
        this.GB = "bj"
    }
    gb.prototype = new Q;
    w.extend(gb.prototype, {
        im: function (a, b) {
            return this.cP(b, Q.Eb(a))
        },
        Vg: function (a, b) {
            return Q.sb(this.dP(b, a))
        },
        lngLatToPointFor3D: function (a, b) {
            var c = this,
                d = Q.Eb(a);
            I.load("coordtrans", function () {
                var a = gc.aD(c.GB || "bj", d),
                    a = new P(a.x, a.y);
                b && b(a)
            }, o)
        },
        pointToLngLatFor3D: function (a, b) {
            var c = this,
                d = new H(a.x, a.y);
            I.load("coordtrans", function () {
                var a = gc.$C(c.GB || "bj", d),
                    a = new H(a.lng, a.lat),
                    a = Q.sb(a);
                b && b(a)
            }, o)
        },
        cP: function (a, b) {
            if (I.Va("coordtrans").jd == I.nj.up) {
                var c = gc.aD(a || "bj", b);
                return new H(c.x, c.y)
            }
            I.load("coordtrans", s());
            return new H(0, 0)
        },
        dP: function (a, b) {
            if (I.Va("coordtrans").jd == I.nj.up) {
                var c = gc.$C(a || "bj", b);
                return new H(c.lng, c.lat)
            }
            I.load("coordtrans", s());
            return new H(0, 0)
        },
        gc: function (a) {
            return Math.pow(2, 20 - a)
        }
    });

    function hc() {
        this.yb = "overlay"
    }
    w.lang.ja(hc, w.lang.ra, "Overlay");
    hc.Yl = function (a) {
        a *= 1;
        return !a ? 0 : -1E5 * a << 1
    };
    w.extend(hc.prototype, {
        Le: function (a) {
            if (!this.K && Wa(this.initialize) && (this.K = this.initialize(a))) this.K.style.WebkitUserSelect = "none";
            this.draw()
        },
        initialize: function () {
            aa("initialize\u65b9\u6cd5\u672a\u5b9e\u73b0")
        },
        draw: function () {
            aa("draw\u65b9\u6cd5\u672a\u5b9e\u73b0")
        },
        remove: function () {
            this.K && this.K.parentNode && this.K.parentNode.removeChild(this.K);
            this.K = p;
            this.dispatchEvent(new L("onremove"))
        },
        J: function () {
            this.K && w.B.J(this.K)
        },
        show: function () {
            this.K && w.B.show(this.K)
        },
        Rg: function () {
            return !this.K || "none" == this.K.style.display || "hidden" == this.K.style.visibility ? q : o
        }
    });
    z.Fe(function (a) {
        function b(a, b) {
            var c = J("div"),
                g = c.style;
            g.position = "absolute";
            g.top = g.left = g.width = g.height = "0";
            g.zIndex = b;
            a.appendChild(c);
            return c
        }
        var c = a.H;
        c.$c = a.$c = b(a.platform, 200);
        a.Xd.EC = b(c.$c, 800);
        a.Xd.PD = b(c.$c, 700);
        a.Xd.TJ = b(c.$c, 600);
        a.Xd.JD = b(c.$c, 500);
        a.Xd.rL = b(c.$c, 400);
        a.Xd.sL = b(c.$c, 300);
        a.Xd.kZ = b(c.$c, 201);
        a.Xd.Ds = b(c.$c, 200)
    });

    function fb() {
        w.lang.ra.call(this);
        hc.call(this);
        this.map = p;
        this.Da = o;
        this.kb = p;
        this.hG = 0
    }
    w.lang.ja(fb, hc, "OverlayInternal");
    w.extend(fb.prototype, {
        initialize: function (a) {
            this.map = a;
            w.lang.ra.call(this, this.Q);
            return p
        },
        Bw: u("map"),
        draw: s(),
        remove: function () {
            this.map = p;
            w.lang.fw(this.Q);
            hc.prototype.remove.call(this)
        },
        J: function () {
            this.Da != q && (this.Da = q)
        },
        show: function () {
            this.Da != o && (this.Da = o)
        },
        Rg: function () {
            return !this.K ? q : !!this.Da
        },
        Fa: u("K"),
        vM: function (a) {
            var a = a || {},
                b;
            for (b in a) this.z[b] = a[b]
        },
        bt: ba("zIndex"),
        Ti: function () {
            this.z.Ti = o
        },
        pU: function () {
            this.z.Ti = q
        },
        On: ba("Rf"),
        So: function () {
            this.Rf = p
        }
    });

    function ic() {
        this.map = p;
        this.ka = {};
        this.me = []
    }
    z.Fe(function (a) {
        var b = new ic;
        b.map = a;
        a.ka = b.ka;
        a.me = b.me;
        a.addEventListener("load", function (a) {
            b.draw(a)
        });
        a.addEventListener("moveend", function (a) {
            b.draw(a)
        });
        w.S.ba && 8 > w.S.ba || "BackCompat" == document.compatMode ? a.addEventListener("zoomend", function (a) {
            setTimeout(function () {
                b.draw(a)
            }, 20)
        }) : a.addEventListener("zoomend", function (a) {
            b.draw(a)
        });
        a.addEventListener("maptypechange", function (a) {
            b.draw(a)
        });
        a.addEventListener("addoverlay", function (a) {
            a = a.target;
            if (a instanceof fb) b.ka[a.Q] || (b.ka[a.Q] = a);
            else {
                for (var d = q, e = 0, f = b.me.length; e < f; e++)
                    if (b.me[e] === a) {
                        d = o;
                        break
                    }
                d || b.me.push(a)
            }
        });
        a.addEventListener("removeoverlay", function (a) {
            a = a.target;
            if (a instanceof fb) delete b.ka[a.Q];
            else
                for (var d = 0, e = b.me.length; d < e; d++)
                    if (b.me[d] === a) {
                        b.me.splice(d, 1);
                        break
                    }
        });
        a.addEventListener("clearoverlays", function () {
            this.Jc();
            for (var a in b.ka) b.ka[a].z.Ti && (b.ka[a].remove(), delete b.ka[a]);
            a = 0;
            for (var d = b.me.length; a < d; a++) b.me[a].Ti != q && (b.me[a].remove(), b.me[a] = p, b.me.splice(a, 1), a--, d--)
        });
        a.addEventListener("infowindowopen", function () {
            var a = this.kb;
            a && (w.B.J(a.jc), w.B.J(a.Pb))
        });
        a.addEventListener("movestart", function () {
            this.Mg() && this.Mg().SH()
        });
        a.addEventListener("moveend", function () {
            this.Mg() && this.Mg().IH()
        })
    });
    ic.prototype.draw = function (a) {
        if (z.yp) {
            var b = z.yp.$r(this.map);
            "canvas" == b.yb && b.canvas && b.YO(b.canvas.getContext("2d"))
        }
        for (var c in this.ka) this.ka[c].draw(a);
        w.Zb.Fb(this.me, function (a) {
            a.draw()
        });
        this.map.H.ab && this.map.H.ab.ha();
        z.yp && b.CE()
    };

    function jc(a) {
        fb.call(this);
        a = a || {};
        this.z = {
            strokeColor: a.strokeColor || "#3a6bdb",
            rc: a.strokeWeight || 5,
            vd: a.strokeOpacity || 0.65,
            strokeStyle: a.strokeStyle || "solid",
            Ti: a.enableMassClear === q ? q : o,
            Yj: p,
            Tl: p,
            xf: a.enableEditing === o ? o : q,
            AL: 5,
            cZ: q,
            Qe: a.enableClicking === q ? q : o,
            Th: a.icons && 0 < a.icons.length ? a.icons : p
        };
        0 >= this.z.rc && (this.z.rc = 5);
        if (0 > this.z.vd || 1 < this.z.vd) this.z.vd = 0.65;
        if (0 > this.z.$f || 1 < this.z.$f) this.z.$f = 0.65;
        "solid" != this.z.strokeStyle && "dashed" != this.z.strokeStyle && (this.z.strokeStyle = "solid");
        this.K = p;
        this.bu = new eb(0, 0);
        this.Ne = [];
        this.Yb = [];
        this.Ga = {}
    }
    w.lang.ja(jc, fb, "Graph");
    jc.xw = function (a) {
        var b = [];
        if (!a) return b;
        Ya(a) && w.Zb.Fb(a.split(";"), function (a) {
            a = a.split(",");
            b.push(new H(a[0], a[1]))
        });
        "[object Array]" == Object.prototype.toString.apply(a) && 0 < a.length && (b = a);
        return b
    };
    jc.$D = [0.09, 0.0050, 1.0E-4, 1.0E-5];
    w.extend(jc.prototype, {
        initialize: function (a) {
            this.map = a;
            return p
        },
        draw: s(),
        br: function (a) {
            this.Ne.length = 0;
            this.W = jc.xw(a).slice(0);
            this.ih()
        },
        ie: function (a) {
            this.br(a)
        },
        ih: function () {
            if (this.W) {
                var a = this;
                a.bu = new eb;
                w.Zb.Fb(this.W, function (b) {
                    a.bu.extend(b)
                })
            }
        },
        ce: u("W"),
        Dm: function (a, b) {
            b && this.W[a] && (this.Ne.length = 0, this.W[a] = new H(b.lng, b.lat), this.ih())
        },
        setStrokeColor: function (a) {
            this.z.strokeColor = a
        },
        HV: function () {
            return this.z.strokeColor
        },
        ip: function (a) {
            0 < a && (this.z.rc = a)
        },
        rK: function () {
            return this.z.rc
        },
        gp: function (a) {
            a == j || (1 < a || 0 > a) || (this.z.vd = a)
        },
        IV: function () {
            return this.z.vd
        },
        Vs: function (a) {
            1 < a || 0 > a || (this.z.$f = a)
        },
        gV: function () {
            return this.z.$f
        },
        hp: function (a) {
            "solid" != a && "dashed" != a || (this.z.strokeStyle = a)
        },
        qK: function () {
            return this.z.strokeStyle
        },
        setFillColor: function (a) {
            this.z.fillColor = a || ""
        },
        fV: function () {
            return this.z.fillColor
        },
        Ld: u("bu"),
        remove: function () {
            this.map && this.map.removeEventListener("onmousemove", this.Au);
            fb.prototype.remove.call(this);
            this.Ne.length = 0
        },
        xf: function () {
            if (!(2 > this.W.length)) {
                this.z.xf = o;
                var a = this;
                I.load("poly", function () {
                    a.rl()
                }, o)
            }
        },
        oU: function () {
            this.z.xf = q;
            var a = this;
            I.load("poly", function () {
                a.Oj()
            }, o)
        }
    });

    function kc(a) {
        fb.call(this);
        this.K = this.map = p;
        this.z = {
            width: 0,
            height: 0,
            pa: new K(0, 0),
            opacity: 1,
            background: "transparent",
            $w: 1,
            dL: "#000",
            EW: "solid",
            point: p
        };
        this.vM(a);
        this.point = this.z.point
    }
    w.lang.ja(kc, fb, "Division");
    w.extend(kc.prototype, {
        Bk: function () {
            var a = this.z,
                b = this.content,
                c = ['<div class="BMap_Division" style="position:absolute;'];
            c.push("width:" + a.width + "px;display:block;");
            c.push("overflow:hidden;");
            "none" != a.borderColor && c.push("border:" + a.$w + "px " + a.EW + " " + a.dL + ";");
            c.push("opacity:" + a.opacity + "; filter:(opacity=" + 100 * a.opacity + ")");
            c.push("background:" + a.background + ";");
            c.push('z-index:60;">');
            c.push(b);
            c.push("</div>");
            this.K = Ab(this.map.Bf().PD, c.join(""))
        },
        initialize: function (a) {
            this.map = a;
            this.Bk();
            this.K && w.F(this.K, G() ? "touchstart" : "mousedown", function (a) {
                oa(a)
            });
            return this.K
        },
        draw: function () {
            var a = this.map.Ee(this.z.point);
            this.z.pa = new K(-Math.round(this.z.width / 2) - Math.round(this.z.$w), -Math.round(this.z.height / 2) - Math.round(this.z.$w));
            this.K.style.left = a.x + this.z.pa.width + "px";
            this.K.style.top = a.y + this.z.pa.height + "px"
        },
        V: function () {
            return this.z.point
        },
        TZ: function () {
            return this.map.Ub(this.V())
        },
        ha: function (a) {
            this.z.point = a;
            this.draw()
        },
        UX: function (a, b) {
            this.z.width = Math.round(a);
            this.z.height = Math.round(b);
            this.K && (this.K.style.width = this.z.width + "px", this.K.style.height = this.z.height + "px", this.draw())
        }
    });

    function lc(a, b, c) {
        a && b && (this.imageUrl = a, this.size = b, a = new K(Math.floor(b.width / 2), Math.floor(b.height / 2)), c = c || {}, a = c.anchor || a, b = c.imageOffset || new K(0, 0), this.imageSize = c.imageSize, this.anchor = a, this.imageOffset = b, this.infoWindowAnchor = c.infoWindowAnchor || this.anchor, this.printImageUrl = c.printImageUrl || "")
    }
    w.extend(lc.prototype, {
        bY: function (a) {
            a && (this.imageUrl = a)
        },
        mY: function (a) {
            a && (this.printImageUrl = a)
        },
        sd: function (a) {
            a && (this.size = new K(a.width, a.height))
        },
        lc: function (a) {
            a && (this.anchor = new K(a.width, a.height))
        },
        Ws: function (a) {
            a && (this.imageOffset = new K(a.width, a.height))
        },
        dY: function (a) {
            a && (this.infoWindowAnchor = new K(a.width, a.height))
        },
        $X: function (a) {
            a && (this.imageSize = new K(a.width, a.height))
        },
        toString: da("Icon")
    });

    function mc(a, b) {
        if (a) {
            b = b || {};
            this.style = {
                anchor: b.anchor || new K(0, 0),
                fillColor: b.fillColor || "#000",
                $f: b.fillOpacity || 0,
                scale: b.scale || 1,
                rotation: b.rotation || 0,
                strokeColor: b.strokeColor || "#000",
                vd: b.strokeOpacity || 1,
                rc: b.strokeWeight
            };
            this.yb = "number" === typeof a ? a : "UserDefined";
            this.oi = this.style.anchor;
            this.Fq = new K(0, 0);
            this.anchor = p;
            this.uA = a;
            var c = this;
            I.load("symbol", function () {
                c.Zm()
            }, o)
        }
    }
    w.extend(mc.prototype, {
        setPath: ba("uA"),
        setAnchor: function (a) {
            this.oi = this.style.anchor = a
        },
        setRotation: function (a) {
            this.style.rotation = a
        },
        setScale: function (a) {
            this.style.scale = a
        },
        setStrokeWeight: function (a) {
            this.style.rc = a
        },
        setStrokeColor: function (a) {
            a = w.wr.BB(a, this.style.vd);
            this.style.strokeColor = a
        },
        setStrokeOpacity: function (a) {
            this.style.vd = a
        },
        setFillOpacity: function (a) {
            this.style.$f = a
        },
        setFillColor: function (a) {
            this.style.fillColor = a
        }
    });

    function nc(a, b, c, d) {
        a && (this.Uu = {}, this.SJ = d ? !!d : q, this.Hc = [], this.CY = a instanceof mc ? a : p, this.BH = b === j ? o : !!(b.indexOf("%") + 1), this.Ej = isNaN(parseFloat(b)) ? 1 : this.BH ? parseFloat(b) / 100 : parseFloat(b), this.CH = !!(c.indexOf("%") + 1), this.repeat = c != j ? this.CH ? parseFloat(c) / 100 : parseFloat(c) : 0)
    };

    function oc(a, b) {
        w.lang.ra.call(this);
        this.content = a;
        this.map = p;
        b = b || {};
        this.z = {
            width: b.width || 0,
            height: b.height || 0,
            maxWidth: b.maxWidth || 730,
            pa: b.offset || new K(0, 0),
            title: b.title || "",
            QD: b.maxContent || "",
            Gg: b.enableMaximize || q,
            Tr: b.enableAutoPan === q ? q : o,
            qC: b.enableCloseOnClick === q ? q : o,
            margin: b.margin || [10, 10, 40, 10],
            wB: b.collisions || [[10, 10], [10, 10], [10, 10], [10, 10]],
            dW: q,
            ZW: b.onClosing || da(o),
            JJ: q,
            vC: b.enableParano === o ? o : q,
            message: b.message,
            xC: b.enableSearchTool === o ? o : q,
            Mw: b.headerContent || "",
            rC: b.enableContentScroll || q
        };
        if (0 != this.z.width && (220 > this.z.width && (this.z.width = 220), 730 < this.z.width)) this.z.width = 730;
        if (0 != this.z.height && (60 > this.z.height && (this.z.height = 60), 650 < this.z.height)) this.z.height = 650;
        if (0 != this.z.maxWidth && (220 > this.z.maxWidth && (this.z.maxWidth = 220), 730 < this.z.maxWidth)) this.z.maxWidth = 730;
        this.Nd = q;
        this.ki = E.ea;
        this.Qa = p;
        var c = this;
        I.load("infowindow", function () {
            c.rb()
        })
    }
    w.lang.ja(oc, w.lang.ra, "InfoWindow");
    w.extend(oc.prototype, {
        setWidth: function (a) {
            !a && 0 != a || (isNaN(a) || 0 > a) || (0 != a && (220 > a && (a = 220), 730 < a && (a = 730)), this.z.width = a)
        },
        setHeight: function (a) {
            !a && 0 != a || (isNaN(a) || 0 > a) || (0 != a && (60 > a && (a = 60), 650 < a && (a = 650)), this.z.height = a)
        },
        yM: function (a) {
            !a && 0 != a || (isNaN(a) || 0 > a) || (0 != a && (220 > a && (a = 220), 730 < a && (a = 730)), this.z.maxWidth = a)
        },
        qc: function (a) {
            this.z.title = a
        },
        getTitle: function () {
            return this.z.title
        },
        Pc: ba("content"),
        Wj: u("content"),
        Ys: function (a) {
            this.z.QD = a + ""
        },
        Td: s(),
        Tr: function () {
            this.z.Tr = o
        },
        disableAutoPan: function () {
            this.z.Tr = q
        },
        enableCloseOnClick: function () {
            this.z.qC = o
        },
        disableCloseOnClick: function () {
            this.z.qC = q
        },
        Gg: function () {
            this.z.Gg = o
        },
        jw: function () {
            this.z.Gg = q
        },
        show: function () {
            this.Da = o
        },
        J: function () {
            this.Da = q
        },
        close: function () {
            this.J()
        },
        fx: function () {
            this.Nd = o
        },
        restore: function () {
            this.Nd = q
        },
        Rg: function () {
            return this.Ja()
        },
        Ja: da(q),
        V: function () {
            if (this.Qa && this.Qa.V) return this.Qa.V()
        },
        Af: function () {
            return this.z.pa
        }
    });
    Ka.prototype.zb = function (a, b) {
        if (a instanceof oc && b instanceof H) {
            var c = this.H;
            c.km ? c.km.ha(b) : (c.km = new R(b, {
                icon: new lc(E.ea + "blank.gif", {
                    width: 1,
                    height: 1
                }),
                offset: new K(0, 0),
                clickable: q
            }), c.km.YP = 1);
            this.xa(c.km);
            c.km.zb(a)
        }
    };
    Ka.prototype.Jc = function () {
        var a = this.H.ab || this.H.Mk;
        a && a.Qa && a.Qa.Jc()
    };
    fb.prototype.zb = function (a) {
        this.map && (this.map.Jc(), a.Da = o, this.map.H.Mk = a, a.Qa = this, w.lang.ra.call(a, a.Q))
    };
    fb.prototype.Jc = function () {
        this.map && this.map.H.Mk && (this.map.H.Mk.Da = q, w.lang.fw(this.map.H.Mk.Q), this.map.H.Mk = p)
    };

    function pc(a, b) {
        fb.call(this);
        this.content = a;
        this.K = this.map = p;
        b = b || {};
        this.z = {
            width: 0,
            pa: b.offset || new K(0, 0),
            kp: {
                backgroundColor: "#fff",
                border: "1px solid #f00",
                padding: "1px",
                whiteSpace: "nowrap",
                font: "12px " + E.fontFamily,
                zIndex: "80",
                MozUserSelect: "none"
            },
            position: b.position || p,
            Ti: b.enableMassClear === q ? q : o,
            Qe: o
        };
        0 > this.z.width && (this.z.width = 0);
        Gb(b.enableClicking) && (this.z.Qe = b.enableClicking);
        this.point = this.z.position;
        var c = this;
        I.load("marker", function () {
            c.rb()
        })
    }
    w.lang.ja(pc, fb, "Label");
    w.extend(pc.prototype, {
        V: function () {
            return this.Ju ? this.Ju.V() : this.point
        },
        ha: function (a) {
            a instanceof H && !this.Cw() && (this.point = this.z.position = new H(a.lng, a.lat))
        },
        Pc: ba("content"),
        BE: function (a) {
            0 <= a && 1 >= a && (this.z.opacity = a)
        },
        he: function (a) {
            a instanceof K && (this.z.pa = new K(a.width, a.height))
        },
        Af: function () {
            return this.z.pa
        },
        td: function (a) {
            a = a || {};
            this.z.kp = w.extend(this.z.kp, a)
        },
        di: function (a) {
            return this.td(a)
        },
        qc: function (a) {
            this.z.title = a || ""
        },
        getTitle: function () {
            return this.z.title
        },
        xM: function (a) {
            this.point = (this.Ju = a) ? this.z.position = a.V() : this.z.position = p
        },
        Cw: function () {
            return this.Ju || p
        },
        Wj: u("content")
    });

    function qc(a, b) {
        if (0 !== arguments.length) {
            fb.apply(this, arguments);
            b = b || {};
            this.z = {
                Ua: a,
                opacity: b.opacity || 1,
                dm: b.dm || "",
                Lr: b.displayOnMinLevel || 1,
                Kr: b.displayOnMaxLevel || 19
            };
            var c = this;
            I.load("groundoverlay", function () {
                c.rb()
            })
        }
    }
    w.lang.ja(qc, fb, "GroundOverlay");
    w.extend(qc.prototype, {
        setBounds: function (a) {
            this.z.Ua = a
        },
        getBounds: function () {
            return this.z.Ua
        },
        setOpacity: function (a) {
            this.z.opacity = a
        },
        getOpacity: function () {
            return this.z.opacity
        },
        setImageURL: function (a) {
            this.z.dm = a
        },
        getImageURL: function () {
            return this.z.dm
        },
        setDispalyOnMinLevel: function (a) {
            this.z.Lr = a
        },
        getDispalyOnMinLevel: function () {
            return this.z.Lr
        },
        setDispalyOnMaxLevel: function (a) {
            this.z.Kr = a
        },
        getDispalyOnMaxLevel: function () {
            return this.z.Kr
        }
    });
    var rc = 3,
        sc = 4;

    function tc() {
        var a = document.createElement("canvas");
        return !(!a.getContext || !a.getContext("2d"))
    }

    function uc(a, b) {
        var c = this;
        tc() && (a === j && aa(Error("\u6ca1\u6709\u4f20\u5165points\u6570\u636e")), "[object Array]" !== Object.prototype.toString.call(a) && aa(Error("points\u6570\u636e\u4e0d\u662f\u6570\u7ec4")), b = b || {}, fb.apply(c, arguments), c.R = {
            W: a
        }, c.z = {
            shape: b.shape || rc,
            size: b.size || sc,
            color: b.color || "#fa937e",
            Ti: o
        }, this.rA = [], this.Yd = [], I.load("pointcollection", function () {
            for (var a = 0, b; b = c.rA[a]; a++) c[b.method].apply(c, b.arguments);
            for (a = 0; b = c.Yd[a]; a++) c[b.method].apply(c, b.arguments)
        }))
    }
    w.lang.ja(uc, fb, "PointCollection");
    w.extend(uc.prototype, {
        initialize: function (a) {
            this.rA && this.rA.push({
                method: "initialize",
                arguments: arguments
            })
        },
        setPoints: function (a) {
            this.Yd && this.Yd.push({
                method: "setPoints",
                arguments: arguments
            })
        },
        setStyles: function (a) {
            this.Yd && this.Yd.push({
                method: "setStyles",
                arguments: arguments
            })
        },
        clear: function () {
            this.Yd && this.Yd.push({
                method: "clear",
                arguments: arguments
            })
        },
        remove: function () {
            this.Yd && this.Yd.push({
                method: "remove",
                arguments: arguments
            })
        }
    });
    var vc = new lc(E.ea + "marker_red_sprite.png", new K(19, 25), {
            anchor: new K(10, 25),
            infoWindowAnchor: new K(10, 0)
        }),
        wc = new lc(E.ea + "marker_red_sprite.png", new K(20, 11), {
            anchor: new K(6, 11),
            imageOffset: new K(-19, -13)
        });

    function R(a, b) {
        fb.call(this);
        b = b || {};
        this.point = a;
        this.Lp = this.map = p;
        this.z = {
            pa: b.offset || new K(0, 0),
            Qg: b.icon || vc,
            ok: wc,
            title: b.title || "",
            label: p,
            RI: b.baseZIndex || 0,
            Qe: o,
            l2: q,
            FD: q,
            Ti: b.enableMassClear === q ? q : o,
            Rb: q,
            fM: b.raiseOnDrag === o ? o : q,
            mM: q,
            ld: b.draggingCursor || E.ld,
            rotation: b.rotation || 0
        };
        b.icon && !b.shadow && (this.z.ok = p);
        b.enableDragging && (this.z.Rb = b.enableDragging);
        Gb(b.enableClicking) && (this.z.Qe = b.enableClicking);
        var c = this;
        I.load("marker", function () {
            c.rb()
        })
    }
    R.Ut = hc.Yl(-90) + 1E6;
    R.pF = R.Ut + 1E6;
    w.lang.ja(R, fb, "Marker");
    w.extend(R.prototype, {
        Ob: function (a) {
            if (a instanceof lc || a instanceof mc) this.z.Qg = a
        },
        po: function () {
            return this.z.Qg
        },
        Jx: function (a) {
            a instanceof lc && (this.z.ok = a)
        },
        getShadow: function () {
            return this.z.ok
        },
        Bm: function (a) {
            this.z.label = a || p
        },
        XC: function () {
            return this.z.label
        },
        Rb: function () {
            this.z.Rb = o
        },
        VB: function () {
            this.z.Rb = q
        },
        V: u("point"),
        ha: function (a) {
            a instanceof H && (this.point = new H(a.lng, a.lat))
        },
        ei: function (a, b) {
            this.z.FD = !!a;
            a && (this.LF = b || 0)
        },
        qc: function (a) {
            this.z.title = a + ""
        },
        getTitle: function () {
            return this.z.title
        },
        he: function (a) {
            a instanceof K && (this.z.pa = a)
        },
        Af: function () {
            return this.z.pa
        },
        Am: ba("Lp"),
        fp: function (a) {
            this.z.rotation = a
        },
        oK: function () {
            return this.z.rotation
        }
    });

    function xc(a, b) {
        jc.call(this, b);
        b = b || {};
        this.z.$f = b.fillOpacity ? b.fillOpacity : 0.65;
        this.z.fillColor = "" == b.fillColor ? "" : b.fillColor ? b.fillColor : "#fff";
        this.ie(a);
        var c = this;
        I.load("poly", function () {
            c.rb()
        })
    }
    w.lang.ja(xc, jc, "Polygon");
    w.extend(xc.prototype, {
        ie: function (a, b) {
            this.Ln = jc.xw(a).slice(0);
            var c = jc.xw(a).slice(0);
            1 < c.length && c.push(new H(c[0].lng, c[0].lat));
            jc.prototype.ie.call(this, c, b)
        },
        Dm: function (a, b) {
            this.Ln[a] && (this.Ln[a] = new H(b.lng, b.lat), this.W[a] = new H(b.lng, b.lat), 0 == a && !this.W[0].$a(this.W[this.W.length - 1]) && (this.W[this.W.length - 1] = new H(b.lng, b.lat)), this.ih())
        },
        ce: function () {
            var a = this.Ln;
            0 == a.length && (a = this.W);
            return a
        }
    });

    function yc(a, b) {
        jc.call(this, b);
        this.br(a);
        var c = this;
        I.load("poly", function () {
            c.rb()
        })
    }
    w.lang.ja(yc, jc, "Polyline");

    function zc(a, b, c) {
        this.point = a;
        this.ma = Math.abs(b);
        xc.call(this, [], c)
    }
    zc.$D = [0.01, 1.0E-4, 1.0E-5, 4.0E-6];
    w.lang.ja(zc, xc, "Circle");
    w.extend(zc.prototype, {
        initialize: function (a) {
            this.map = a;
            this.W = this.wu(this.point, this.ma);
            this.ih();
            return p
        },
        za: u("point"),
        Gf: function (a) {
            a && (this.point = a)
        },
        mK: u("ma"),
        af: function (a) {
            this.ma = Math.abs(a)
        },
        wu: function (a, b) {
            if (!a || !b || !this.map) return [];
            for (var c = [], d = b / 6378800, e = Math.PI / 180 * a.lat, f = Math.PI / 180 * a.lng, g = 0; 360 > g; g += 9) {
                var i = Math.PI / 180 * g,
                    k = Math.asin(Math.sin(e) * Math.cos(d) + Math.cos(e) * Math.sin(d) * Math.cos(i)),
                    i = new H(((f - Math.atan2(Math.sin(i) * Math.sin(d) * Math.cos(e), Math.cos(d) - Math.sin(e) * Math.sin(k)) + Math.PI) % (2 * Math.PI) - Math.PI) * (180 / Math.PI), k * (180 / Math.PI));
                c.push(i)
            }
            d = c[0];
            c.push(new H(d.lng, d.lat));
            return c
        }
    });
    var Ac = {};

    function Bc(a) {
        this.map = a;
        this.jm = [];
        this.Hf = [];
        this.mg = [];
        this.BT = 300;
        this.jE = 0;
        this.fg = {};
        this.Li = {};
        this.Xg = 0;
        this.zD = o;
        this.pJ = {};
        this.vn = this.bn(1);
        this.Xc = this.bn(2);
        this.Wk = this.bn(3);
        a.platform.appendChild(this.vn);
        a.platform.appendChild(this.Xc);
        a.platform.appendChild(this.Wk)
    }
    z.Fe(function (a) {
        var b = new Bc(a);
        b.fa();
        a.ib = b
    });
    w.extend(Bc.prototype, {
        fa: function () {
            var a = this,
                b = a.map;
            b.addEventListener("loadcode", function () {
                a.ax()
            });
            b.addEventListener("addtilelayer", function (b) {
                a.Cg(b)
            });
            b.addEventListener("removetilelayer", function (b) {
                a.dh(b)
            });
            b.addEventListener("setmaptype", function (b) {
                a.jg(b)
            });
            b.addEventListener("zoomstartcode", function (b) {
                a.Ac(b)
            });
            b.addEventListener("setcustomstyles", function (b) {
                a.Xs(b.target);
                a.Ef(o)
            })
        },
        ax: function () {
            var a = this;
            if (w.S.ba) try {
                document.execCommand("BackgroundImageCache", q, o)
            } catch (b) {}
            this.loaded || a.Sw();
            a.Ef();
            this.loaded || (this.loaded = o, I.load("tile", function () {
                a.wO()
            }))
        },
        Sw: function () {
            for (var a = this.map.ia().Aq, b = 0; b < a.length; b++) {
                var c = new Cc;
                w.extend(c, a[b]);
                this.jm.push(c);
                c.fa(this.map, this.vn)
            }
            this.Xs()
        },
        bn: function (a) {
            var b = J("div");
            b.style.position = "absolute";
            b.style.overflow = "visible";
            b.style.left = b.style.top = "0";
            b.style.zIndex = a;
            return b
        },
        ef: function () {
            this.Xg--;
            var a = this;
            this.zD && (this.map.dispatchEvent(new L("onfirsttileloaded")), this.zD = q);
            0 == this.Xg && (this.ri && (clearTimeout(this.ri), this.ri = p), this.ri = setTimeout(function () {
                if (a.Xg == 0) {
                    a.map.dispatchEvent(new L("ontilesloaded"));
                    a.zD = o
                }
                a.ri = p
            }, 80))
        },
        hD: function (a, b) {
            return "TILE-" + b.Q + "-" + a[0] + "-" + a[1] + "-" + a[2]
        },
        Pw: function (a) {
            var b = a.tb;
            b && zb(b) && b.parentNode.removeChild(b);
            delete this.fg[a.name];
            a.loaded || (Dc(a), a.tb = p, a.mm = p)
        },
        Xl: function (a, b, c) {
            var d = this.map,
                e = d.ia(),
                f = d.va,
                g = d.hc,
                i = e.gc(f),
                k = this.cK(),
                l = k[0],
                m = k[1],
                n = k[2],
                t = k[3],
                v = k[4],
                c = "undefined" != typeof c ? c : 0,
                e = e.k.ub,
                k = d.Q.replace(/^TANGRAM_/, "");
            for (this.Dc ? this.Dc.length = 0 : this.Dc = []; l < n; l++)
                for (var x = m; x < t; x++) {
                    var y = l,
                        B = x;
                    this.Dc.push([y, B]);
                    y = k + "_" + b + "_" + y + "_" + B + "_" + f;
                    this.pJ[y] = y
                }
            this.Dc.sort(function (a) {
                return function (b, c) {
                    return 0.4 * Math.abs(b[0] - a[0]) + 0.6 * Math.abs(b[1] - a[1]) - (0.4 * Math.abs(c[0] - a[0]) + 0.6 * Math.abs(c[1] - a[1]))
                }
            }([v[0] - 1, v[1] - 1]));
            g = [Math.round(-g.lng / i), Math.round(g.lat / i)];
            l = -d.offsetY + d.height / 2;
            a.style.left = -d.offsetX + d.width / 2 + "px";
            a.style.top = l + "px";
            this.xe ? this.xe.length = 0 : this.xe = [];
            l = 0;
            for (d = a.childNodes.length; l < d; l++) x = a.childNodes[l], x.wq = q, this.xe.push(x);
            if (l = this.pm)
                for (var A in l) delete l[A];
            else this.pm = {};
            this.ye ? this.ye.length = 0 : this.ye = [];
            l = 0;
            for (d = this.Dc.length; l < d; l++) {
                A = this.Dc[l][0];
                i = this.Dc[l][1];
                x = 0;
                for (m = this.xe.length; x < m; x++)
                    if (n = this.xe[x], n.id == k + "_" + b + "_" + A + "_" + i + "_" + f) {
                        n.wq = o;
                        this.pm[n.id] = n;
                        break
                    }
            }
            l = 0;
            for (d = this.xe.length; l < d; l++) n = this.xe[l], n.wq || this.ye.push(n);
            this.Im = [];
            x = (e + c) * this.map.D.devicePixelRatio;
            l = 0;
            for (d = this.Dc.length; l < d; l++) A = this.Dc[l][0], i = this.Dc[l][1], t = A * e + g[0] - c / 2, v = (-1 - i) * e + g[1] - c / 2, y = k + "_" + b + "_" + A + "_" + i + "_" + f, m = this.pm[y], n = p, m ? (n = m.style, n.left = t + "px", n.top = v + "px", m.Je || this.Im.push([A, i, m])) : (0 < this.ye.length ? (m = this.ye.shift(), m.getContext("2d").clearRect(-c / 2, -c / 2, x, x), n = m.style) : (m = document.createElement("canvas"), n = m.style, n.position = "absolute", n.width = e + c + "px", n.height = e + c + "px", this.Ww() && (n.WebkitTransform = "scale(1.001)"), m.setAttribute("width", x), m.setAttribute("height", x), a.appendChild(m)), m.id = y, n.left = t + "px", n.top = v + "px", -1 < y.indexOf("bg") && (t = "#F3F1EC", this.map.D.Tn && (t = this.map.D.Tn), n.background = t ? t : ""), this.Im.push([A, i, m])), m.style.visibility = "";
            l = 0;
            for (d = this.ye.length; l < d; l++) this.ye[l].style.visibility = "hidden";
            return this.Im
        },
        Ww: function () {
            return /M040/i.test(navigator.userAgent)
        },
        cK: function () {
            var a = this.map,
                b = a.ia(),
                c = a.va;
            b.gc(c);
            var c = b.lD(c),
                d = a.hc,
                e = Math.ceil(d.lng / c),
                f = Math.ceil(d.lat / c),
                b = b.k.ub,
                c = [e, f, (d.lng - e * c) / c * b, (d.lat - f * c) / c * b];
            return [c[0] - Math.ceil((a.width / 2 - c[2]) / b), c[1] - Math.ceil((a.height / 2 - c[3]) / b), c[0] + Math.ceil((a.width / 2 + c[2]) / b), c[1] + Math.ceil((a.height / 2 + c[3]) / b), c]
        },
        sY: function (a, b, c, d) {
            var e = this;
            e.x_ = b;
            var f = this.map.ia(),
                g = e.hD(a, c),
                i = f.k.ub,
                b = [a[0] * i + b[0], (-1 - a[1]) * i + b[1]],
                k = this.fg[g];
            k && k.tb ? (xb(k.tb, b), d && (d = new P(a[0], a[1]), f = this.map.D.ee ? this.map.D.ee.style : "normal", d = c.getTilesUrl(d, a[2], f), k.loaded = q, Ec(k, d)), k.loaded ? this.ef() : Fc(k, function () {
                e.ef()
            })) : (k = this.Li[g]) && k.tb ? (c.Cb.insertBefore(k.tb, c.Cb.lastChild), this.fg[g] = k, xb(k.tb, b), d && (d = new P(a[0], a[1]), f = this.map.D.ee ? this.map.D.ee.style : "normal", d = c.getTilesUrl(d, a[2], f), k.loaded = q, Ec(k, d)), k.loaded ? this.ef() : Fc(k, function () {
                e.ef()
            })) : (k = i * Math.pow(2, f.Sl() - a[2]), new H(a[0] * k, a[1] * k), d = new P(a[0], a[1]), f = this.map.D.ee ? this.map.D.ee.style : "normal", d = c.getTilesUrl(d, a[2], f), k = new Gc(this, d, b, a, c), Fc(k, function () {
                e.ef()
            }), Hc(k), this.fg[g] = k)
        },
        ef: function () {
            this.Xg--;
            var a = this;
            0 == this.Xg && (this.ri && (clearTimeout(this.ri), this.ri = p), this.ri = setTimeout(function () {
                if (a.Xg == 0) {
                    a.map.dispatchEvent(new L("ontilesloaded"));
                    if (ua) {
                        if (ra && sa && ta) {
                            var b = $a(),
                                c = a.map.Lb();
                            setTimeout(function () {
                                Pa(5030, {
                                    load_script_time: sa - ra,
                                    load_tiles_time: b - ta,
                                    map_width: c.width,
                                    map_height: c.height,
                                    map_size: c.width * c.height
                                })
                            }, 1E4);
                            va.$b("img_fisrt_loaded");
                            va.$b("map_width", c.width);
                            va.$b("map_height", c.height);
                            va.$b("map_size", c.width * c.height);
                            va.vm()
                        }
                        ua = q
                    }
                }
                a.ri = p
            }, 80))
        },
        hD: function (a, b) {
            return this.map.ia() === Oa ? "TILE-" + b.Q + "-" + this.map.Rv + "-" + a[0] + "-" + a[1] + "-" + a[2] : "TILE-" + b.Q + "-" + a[0] + "-" + a[1] + "-" + a[2]
        },
        Pw: function (a) {
            var b = a.tb;
            b && (Ic(b), zb(b) && b.parentNode.removeChild(b));
            delete this.fg[a.name];
            a.loaded || (Ic(b), Dc(a), a.tb = p, a.mm = p)
        },
        Ef: function (a) {
            var b = this;
            if (b.map.ia() == Oa) I.load("coordtrans", function () {
                b.map.Jb || (b.map.Jb = Oa.Vj(b.map.Xn), b.map.Rv = Oa.aK(b.map.Jb));
                b.iH()
            }, o);
            else {
                if (a && a)
                    for (var c in this.Li) delete this.Li[c];
                b.iH(a)
            }
        },
        iH: function (a) {
            for (var b = this.jm.concat(this.Hf), c = b.length, d = 0; d < c; d++) {
                var e = b[d];
                if (e.Tb && l.va < e.Tb) break;
                if (e.Mv) {
                    var f = this.Cb = e.Cb;
                    if (a) {
                        var g = f;
                        if (g && g.childNodes)
                            for (var i = g.childNodes.length, k = i - 1; 0 <= k; k--) i = g.childNodes[k], g.removeChild(i), i = p
                    }
                    if (this.map.Ib()) {
                        this.Xc.style.display = "block";
                        f.style.display = "none";
                        this.map.dispatchEvent(new L("vectorchanged"), {
                            isvector: o
                        });
                        continue
                    } else f.style.display = "block", this.Xc.style.display = "none", this.map.dispatchEvent(new L("vectorchanged"), {
                        isvector: q
                    })
                }
                if (!e.$G && !(e.Go && !this.map.Ib() || e.WK && this.map.Ib())) {
                    var l = this.map,
                        m = l.ia(),
                        f = m.vo(),
                        i = l.va,
                        n = l.hc;
                    m == Oa && n.$a(new H(0, 0)) && (n = l.hc = f.im(l.Pe, l.Jb));
                    var t = m.gc(i),
                        i = m.lD(i),
                        f = Math.ceil(n.lng / i),
                        g = Math.ceil(n.lat / i),
                        v = m.k.ub,
                        i = [f, g, (n.lng - f * i) / i * v, (n.lat - g * i) / i * v],
                        k = i[0] - Math.ceil((l.width / 2 - i[2]) / v),
                        f = i[1] - Math.ceil((l.height / 2 - i[3]) / v),
                        g = i[0] + Math.ceil((l.width / 2 + i[2]) / v),
                        x = 0;
                    m === Oa && 15 == l.U() && (x = 1);
                    m = i[1] + Math.ceil((l.height / 2 + i[3]) / v) + x;
                    this.NI = new H(n.lng, n.lat);
                    var y = this.fg,
                        v = -this.NI.lng / t,
                        x = this.NI.lat / t,
                        t = [Math.ceil(v), Math.ceil(x)],
                        n = l.U(),
                        B;
                    for (B in y) {
                        var A = y[B],
                            D = A.info;
                        (D[2] != n || D[2] == n && (k > D[0] || g <= D[0] || f > D[1] || m <= D[1])) && this.Pw(A)
                    }
                    y = -l.offsetX + l.width / 2;
                    A = -l.offsetY + l.height / 2;
                    e.Cb && (e.Cb.style.left = Math.ceil(v + y) - t[0] + "px", e.Cb.style.top = Math.ceil(x + A) - t[1] + "px", e.Cb.style.WebkitTransform = "translate3d(0,0,0)");
                    v = [];
                    for (l.VA = []; k < g; k++)
                        for (x = f; x < m; x++) v.push([k, x]), l.VA.push({
                            x: k,
                            y: x
                        });
                    v.sort(function (a) {
                        return function (b, c) {
                            return 0.4 * Math.abs(b[0] - a[0]) + 0.6 * Math.abs(b[1] - a[1]) - (0.4 * Math.abs(c[0] - a[0]) + 0.6 * Math.abs(c[1] - a[1]))
                        }
                    }([i[0] - 1, i[1] - 1]));
                    i = v.length;
                    this.Xg += i;
                    for (k = 0; k < i; k++) this.sY([v[k][0], v[k][1], n], t, e, a)
                }
            }
        },
        Cg: function (a) {
            var b = this,
                c = a.target,
                a = b.map.Ib();
            if (c instanceof cb) a && !c.em && (c.fa(this.map, this.Xc), c.em = o);
            else if (c.If && this.map.Cg(c.If), c.Go) {
                for (a = 0; a < b.mg.length; a++)
                    if (b.mg[a] == c) return;
                I.load("vector", function () {
                    c.fa(b.map, b.Xc);
                    b.mg.push(c)
                }, o)
            } else {
                for (a = 0; a < b.Hf.length; a++)
                    if (b.Hf[a] == c) return;
                c.fa(this.map, this.Wk);
                b.Hf.push(c)
            }
        },
        dh: function (a) {
            var a = a.target,
                b = this.map.Ib();
            if (a instanceof cb) b && a.em && (a.remove(), a.em = q);
            else {
                a.If && this.map.dh(a.If);
                if (a.Go)
                    for (var b = 0, c = this.mg.length; b < c; b++) a == this.mg[b] && this.mg.splice(b, 1);
                else {
                    b = 0;
                    for (c = this.Hf.length; b < c; b++) a == this.Hf[b] && this.Hf.splice(b, 1)
                }
                a.remove()
            }
        },
        jg: function () {
            for (var a = this.jm, b = 0, c = a.length; b < c; b++) a[b].remove();
            delete this.Cb;
            this.jm = [];
            this.Li = this.fg = {};
            this.Sw();
            this.Ef()
        },
        Ac: function () {
            var a = this;
            a.cd && w.B.J(a.cd);
            setTimeout(function () {
                a.Ef();
                a.map.dispatchEvent(new L("onzoomend"))
            }, 10)
        },
        a2: s(),
        Xs: function (a) {
            var b = this.map.ia();
            if (!this.map.Ib() && (a ? this.map.D.zY = a : a = this.map.D.zY, a))
                for (var c = p, c = "2" == z.Yx ? [z.url.proto + z.url.domain.main_domain_cdn.other[0] + "/"] : [z.url.proto + z.url.domain.main_domain_cdn.baidu[0] + "/", z.url.proto + z.url.domain.main_domain_cdn.baidu[1] + "/", z.url.proto + z.url.domain.main_domain_cdn.baidu[2] + "/"], d = 0, e; e = this.jm[d]; d++)
                    if (e.oY == o) {
                        b.k.Mb = 18;
                        this.map.Og() && (b.k.Qw = 18);
                        e.getTilesUrl = function (b, d) {
                            var e = b.x,
                                k = b.y,
                                l = "customimage/tile?&x=" + e + "&y=" + k + "&z=" + d + "&udt=20150601",
                                l = a.styleStr ? l + ("&styles=" + encodeURIComponent(a.styleStr)) : l + ("&customid=" + a.style);
                            return c[Math.abs(e + k) % c.length] + l
                        };
                        break
                    }
        }
    });

    function Gc(a, b, c, d, e) {
        this.mm = a;
        this.position = c;
        this.fu = [];
        this.name = a.hD(d, e);
        this.info = d;
        this.kI = e.As();
        d = J("img");
        yb(d);
        d.VJ = q;
        var f = d.style,
            a = a.map.ia();
        f.position = "absolute";
        f.border = "none";
        f.width = a.k.ub + "px";
        f.height = a.k.ub + "px";
        f.left = c[0] + "px";
        f.top = c[1] + "px";
        f.maxWidth = "none";
        this.tb = d;
        this.src = b;
        Jc && (this.tb.style.opacity = 0);
        var g = this;
        this.tb.onload = function () {
            z.GW.fP();
            g.loaded = o;
            if (g.mm) {
                var a = g.mm,
                    b = a.Li;
                if (!b[g.name]) {
                    a.jE++;
                    b[g.name] = g
                }
                if (g.tb && !zb(g.tb) && e.Cb) {
                    e.Cb.appendChild(g.tb);
                    if (w.S.ba <= 6 && w.S.ba > 0 && g.kI) g.tb.style.cssText = g.tb.style.cssText + (';filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(src="' + g.src + '",sizingMethod=scale);')
                }
                var c = a.jE - a.BT,
                    d;
                for (d in b) {
                    if (c <= 0) break;
                    if (!a.fg[d]) {
                        b[d].mm = p;
                        var f = b[d].tb;
                        if (f && f.parentNode) {
                            f.parentNode.removeChild(f);
                            Ic(f)
                        }
                        f = p;
                        b[d].tb = p;
                        delete b[d];
                        a.jE--;
                        c--
                    }
                }
                Jc && new tb({
                    Lc: 20,
                    duration: 200,
                    la: function (a) {
                        if (g.tb && g.tb.style) g.tb.style.opacity = a * 1
                    },
                    finish: function () {
                        g.tb && g.tb.style && delete g.tb.style.opacity
                    }
                });
                Dc(g)
            }
        };
        this.tb.onerror = function () {
            Dc(g);
            if (g.mm) {
                var a = g.mm.map.ia();
                if (a.k.yC) {
                    g.error = o;
                    g.tb.src = a.k.yC;
                    g.tb && !zb(g.tb) && e.Cb.appendChild(g.tb)
                }
            }
        };
        d = p
    }

    function Fc(a, b) {
        a.fu.push(b)
    }

    function Hc(a) {
        a.tb.src = 0 < w.S.ba && 6 >= w.S.ba && a.kI ? E.ea + "blank.gif" : "" !== a.src && a.tb.src == a.src ? a.src + "&t = " + Date.now() : a.src
    }

    function Dc(a) {
        for (var b = 0; b < a.fu.length; b++) a.fu[b]();
        a.fu.length = 0
    }

    function Ic(a) {
        if (a) {
            a.onload = a.onerror = p;
            var b = a.attributes,
                c, d, e;
            if (b) {
                d = b.length;
                for (c = 0; c < d; c += 1) e = b[c].name, Wa(a[e]) && (a[e] = p)
            }
            if (b = a.children) {
                d = b.length;
                for (c = 0; c < d; c += 1) Ic(a.children[c])
            }
        }
    }

    function Ec(a, b) {
        a.src = b;
        Hc(a)
    }
    var Jc = !w.S.ba || 8 < w.S.ba;

    function Cc(a) {
        this.Oo = a || {};
        this.VT = this.Oo.copyright || p;
        this.ZY = this.Oo.transparentPng || q;
        this.Mv = this.Oo.baseLayer || q;
        this.zIndex = this.Oo.zIndex || 0;
        this.Q = Cc.LQ++
    }
    Cc.LQ = 0;
    w.lang.ja(Cc, w.lang.ra, "TileLayer");
    w.extend(Cc.prototype, {
        fa: function (a, b) {
            this.Mv && (this.zIndex = -100);
            this.map = a;
            if (!this.Cb) {
                var c = J("div"),
                    d = c.style;
                d.position = "absolute";
                d.overflow = "visible";
                d.zIndex = this.zIndex;
                d.left = Math.ceil(-a.offsetX + a.width / 2) + "px";
                d.top = Math.ceil(-a.offsetY + a.height / 2) + "px";
                b.appendChild(c);
                this.Cb = c
            }
            c = a.ia();
            a.Og() && c == La && (c.k.ub = 128, d = function (a) {
                return Math.pow(2, 18 - a) * 2
            }, c.gc = d, c.k.Sd.gc = d)
        },
        remove: function () {
            this.Cb && this.Cb.parentNode && (this.Cb.innerHTML = "", this.Cb.parentNode.removeChild(this.Cb));
            delete this.Cb
        },
        As: u("ZY"),
        getTilesUrl: function (a, b) {
            var c = "";
            this.Oo.tileUrlTemplate && (c = this.Oo.tileUrlTemplate.replace(/\{X\}/, a.x), c = c.replace(/\{Y\}/, a.y), c = c.replace(/\{Z\}/, b));
            return c
        },
        Ql: u("VT"),
        ia: function () {
            return this.lb || La
        }
    });

    function Kc(a, b) {
        Hb(a) ? b = a || {} : (b = b || {}, b.databoxId = a);
        this.k = {
            qJ: b.databoxId,
            Jg: b.geotableId,
            wx: b.q || "",
            ut: b.tags || "",
            filter: b.filter || "",
            Qx: b.sortby || "",
            xY: b.styleId || "",
            sl: b.ak || qa,
            Jv: b.age || 36E5,
            zIndex: 11,
            AW: "VectorCloudLayer",
            dk: b.hotspotName || "vector_md_" + (1E5 * Math.random()).toFixed(0),
            hT: "LBS\u4e91\u9ebb\u70b9\u5c42"
        };
        this.Go = o;
        Cc.call(this, this.k);
        this.jU = z.wc + "geosearch/detail/";
        this.kU = z.wc + "geosearch/v2/detail/";
        this.Co = {}
    }
    w.ja(Kc, Cc, "VectorCloudLayer");

    function Lc(a) {
        a = a || {};
        this.k = w.extend(a, {
            zIndex: 1,
            AW: "VectorTrafficLayer",
            hT: "\u77e2\u91cf\u8def\u51b5\u5c42"
        });
        this.Go = o;
        Cc.call(this, this.k);
        this.VY = z.url.proto + z.url.domain.vector_traffic + "/gvd/?qt=lgvd&styles=pl&layers=tf";
        this.qb = {
            "0": [2, 1354709503, 2, 2, 0, [], 0, 0],
            1: [2, 1354709503, 3, 2, 0, [], 0, 0],
            10: [2, -231722753, 2, 2, 0, [], 0, 0],
            11: [2, -231722753, 3, 2, 0, [], 0, 0],
            12: [2, -231722753, 4, 2, 0, [], 0, 0],
            13: [2, -231722753, 5, 2, 0, [], 0, 0],
            14: [2, -231722753, 6, 2, 0, [], 0, 0],
            15: [2, -1, 4, 0, 0, [], 0, 0],
            16: [2, -1, 5.5, 0, 0, [], 0, 0],
            17: [2, -1, 7, 0, 0, [], 0, 0],
            18: [2, -1, 8.5, 0, 0, [], 0, 0],
            19: [2, -1, 10, 0, 0, [], 0, 0],
            2: [2, 1354709503, 4, 2, 0, [], 0, 0],
            3: [2, 1354709503, 5, 2, 0, [], 0, 0],
            4: [2, 1354709503, 6, 2, 0, [], 0, 0],
            5: [2, -6350337, 2, 2, 0, [], 0, 0],
            6: [2, -6350337, 3, 2, 0, [], 0, 0],
            7: [2, -6350337, 4, 2, 0, [], 0, 0],
            8: [2, -6350337, 5, 2, 0, [], 0, 0],
            9: [2, -6350337, 6, 2, 0, [], 0, 0]
        }
    }
    w.ja(Lc, Cc, "VectorTrafficLayer");

    function cb(a) {
        this.CT = [z.url.proto + z.url.domain.TILE_ONLINE_URLS[1] + "/gvd/?", z.url.proto + z.url.domain.TILE_ONLINE_URLS[2] + "/gvd/?", z.url.proto + z.url.domain.TILE_ONLINE_URLS[3] + "/gvd/?", z.url.proto + z.url.domain.TILE_ONLINE_URLS[4] + "/gvd/?"];
        this.k = {
            RJ: q
        };
        for (var b in a) this.k[b] = a[b];
        this.Fh = this.mh = this.Ka = this.A = this.C = p;
        this.bL = 0;
        var c = this;
        I.load("vector", function () {
            c.cf()
        })
    }
    w.extend(cb.prototype, {
        fa: function (a, b) {
            this.C = a;
            this.A = b
        },
        remove: function () {
            this.A = this.C = p
        }
    });

    function Mc(a) {
        Cc.call(this, a);
        this.k = a || {};
        this.WK = o;
        this.If = new Lc;
        this.If.Wx = this;
        if (this.k.predictDate) {
            if (1 > this.k.predictDate.weekday || 7 < this.k.predictDate.weekday) this.k.predictDate = 1;
            if (0 > this.k.predictDate.hour || 23 < this.k.predictDate.hour) this.k.predictDate.hour = 0
        }
        this.NS = z.url.proto + z.url.domain.traffic + ":8002/traffic/"
    }
    Mc.prototype = new Cc;
    Mc.prototype.fa = function (a, b) {
        Cc.prototype.fa.call(this, a, b);
        this.C = a
    };
    Mc.prototype.As = da(o);
    Mc.prototype.getTilesUrl = function (a, b) {
        var c = "";
        this.k.predictDate ? c = "HistoryService?day=" + (this.k.predictDate.weekday - 1) + "&hour=" + this.k.predictDate.hour + "&t=" + (new Date).getTime() + "&" : (c = "TrafficTileService?time=" + (new Date).getTime() + "&", this.C.Og() || (c += "label=web2D&v=016&"));
        return (this.NS + c + "level=" + b + "&x=" + a.x + "&y=" + a.y).replace(/-(\d+)/gi, "M$1")
    };
    var Nc = [z.url.proto + z.url.domain.TILES_YUN_HOST[0] + "/georender/gss", z.url.proto + z.url.domain.TILES_YUN_HOST[1] + "/georender/gss", z.url.proto + z.url.domain.TILES_YUN_HOST[2] + "/georender/gss", z.url.proto + z.url.domain.TILES_YUN_HOST[3] + "/georender/gss"],
        Oc = 100;

    function nb(a, b) {
        Cc.call(this);
        var c = this;
        this.WK = o;
        var d = q;
        try {
            document.createElement("canvas").getContext("2d"), d = o
        } catch (e) {
            d = q
        }
        d && (this.If = new Kc(a, b), this.If.Wx = this);
        Hb(a) ? b = a || {} : (c.Yp = a, b = b || {});
        b.geotableId && (c.Pf = b.geotableId);
        b.databoxId && (c.Yp = b.databoxId);
        d = z.wc + "geosearch";
        c.oc = {
            mX: b.pointDensity || Oc,
            aW: d + "/detail/",
            bW: d + "/v2/detail/",
            Jv: b.age || 36E5,
            wx: b.q || "",
            IY: "png",
            G0: [5, 5, 5, 5],
            zW: {
                backgroundColor: "#FFFFD5",
                borderColor: "#808080"
            },
            sl: b.ak || qa,
            ut: b.tags || "",
            filter: b.filter || "",
            Qx: b.sortby || "",
            dk: b.hotspotName || "tile_md_" + (1E5 * Math.random()).toFixed(0)
        };
        I.load("clayer", function () {
            c.ke()
        })
    }
    nb.prototype = new Cc;
    nb.prototype.fa = function (a, b) {
        Cc.prototype.fa.call(this, a, b);
        this.C = a
    };
    nb.prototype.getTilesUrl = function (a, b) {
        var c = a.x,
            d = a.y,
            e = this.oc,
            c = Nc[Math.abs(c + d) % Nc.length] + "/image?grids=" + c + "_" + d + "_" + b + "&q=" + e.wx + "&tags=" + e.ut + "&filter=" + e.filter + "&sortby=" + e.Qx + "&ak=" + this.oc.sl + "&age=" + e.Jv + "&page_size=" + e.mX + "&format=" + e.IY;
        this.Pf ? c += "&geotable_id=" + this.Pf : this.Yp && (c += "&databox_id=" + this.Yp);
        return c
    };
    nb.kS = /^point\(|\)$/ig;
    nb.lS = /\s+/;
    nb.nS = /^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g;

    function Pc(a, b, c) {
        this.Me = a;
        this.Aq = b instanceof Cc ? [b] : b.slice(0);
        c = c || {};
        this.k = {
            JY: c.tips || "",
            KD: "",
            Tb: c.minZoom || 3,
            Mb: c.maxZoom || 18,
            ZV: c.minZoom || 3,
            Qw: c.maxZoom || 18,
            ub: 256,
            HY: c.textColor || "black",
            yC: c.errorImageUrl || "",
            Sd: c.projection || new Q
        };
        1 <= this.Aq.length && (this.Aq[0].Mv = o);
        w.extend(this.k, c)
    }
    w.extend(Pc.prototype, {
        getName: u("Me"),
        ks: function () {
            return this.k.JY
        },
        n0: function () {
            return this.k.KD
        },
        NV: function () {
            return this.Aq[0]
        },
        A0: u("Aq"),
        OV: function () {
            return this.k.ub
        },
        qo: function () {
            return this.k.Tb
        },
        Sl: function () {
            return this.k.Mb
        },
        setMaxZoom: function (a) {
            this.k.Mb = a
        },
        js: function () {
            return this.k.HY
        },
        vo: function () {
            return this.k.Sd
        },
        i0: function () {
            return this.k.yC
        },
        OV: function () {
            return this.k.ub
        },
        gc: function (a) {
            return Math.pow(2, 18 - a)
        },
        lD: function (a) {
            return this.gc(a) * this.k.ub
        }
    });
    var Qc = [z.url.proto + z.url.domain.TILE_BASE_URLS[0] + "/it/", z.url.proto + z.url.domain.TILE_BASE_URLS[1] + "/it/", z.url.proto + z.url.domain.TILE_BASE_URLS[2] + "/it/", z.url.proto + z.url.domain.TILE_BASE_URLS[3] + "/it/", z.url.proto + z.url.domain.TILE_BASE_URLS[4] + "/it/"],
        Rc = [z.url.proto + z.url.domain.TILE_ONLINE_URLS[0] + "/tile/", z.url.proto + z.url.domain.TILE_ONLINE_URLS[1] + "/tile/", z.url.proto + z.url.domain.TILE_ONLINE_URLS[2] + "/tile/", z.url.proto + z.url.domain.TILE_ONLINE_URLS[3] + "/tile/", z.url.proto + z.url.domain.TILE_ONLINE_URLS[4] + "/tile/"],
        Sc = {
            dark: "dl",
            light: "ll",
            normal: "pl"
        },
        Tc = new Cc;
    Tc.oY = o;
    Tc.getTilesUrl = function (a, b, c) {
        var d = a.x,
            a = a.y,
            e = "pl",
            f = 1;
        this.map.Og();
        !G() && 2 <= window.devicePixelRatio && (f = 2);
        e = Sc[c];
        return (Rc[Math.abs(d + a) % Rc.length] + "?qt=tile&x=" + (d + "").replace(/-/gi, "M") + "&y=" + (a + "").replace(/-/gi, "M") + "&z=" + b + "&styles=" + e + "&scaler=" + f + (6 == w.S.ba ? "&color_dep=32&colors=50" : "") + "&udt=20150528").replace(/-(\d+)/gi, "M$1")
    };
    var La = new Pc("\u5730\u56fe", Tc, {
            tips: "\u663e\u793a\u666e\u901a\u5730\u56fe",
            maxZoom: 19
        }),
        Uc = new Cc;
    Uc.TM = [z.url.proto + z.url.domain.TIlE_PERSPECT_URLS[0] + "/resource/mappic/", z.url.proto + z.url.domain.TIlE_PERSPECT_URLS[1] + "/resource/mappic/", z.url.proto + z.url.domain.TIlE_PERSPECT_URLS[2] + "/resource/mappic/", z.url.proto + z.url.domain.TIlE_PERSPECT_URLS[3] + "/resource/mappic/"];
    Uc.getTilesUrl = function (a, b) {
        var c = a.x,
            d = a.y,
            e = 256 * Math.pow(2, 20 - b),
            d = Math.round((9998336 - e * d) / e) - 1;
        return url = this.TM[Math.abs(c + d) % this.TM.length] + this.map.Jb + "/" + this.map.Rv + "/3/lv" + (21 - b) + "/" + c + "," + d + ".jpg"
    };
    var Oa = new Pc("\u4e09\u7ef4", Uc, {
        tips: "\u663e\u793a\u4e09\u7ef4\u5730\u56fe",
        minZoom: 15,
        maxZoom: 20,
        textColor: "white",
        projection: new gb
    });
    Oa.gc = function (a) {
        return Math.pow(2, 20 - a)
    };
    Oa.Vj = function (a) {
        if (!a) return "";
        var b = E.qB,
            c;
        for (c in b)
            if (-1 < a.search(c)) return b[c].ux;
        return ""
    };
    Oa.aK = function (a) {
        return {
            bj: 2,
            gz: 1,
            sz: 14,
            sh: 4
        }[a]
    };
    var Vc = new Cc({
        Mv: o
    });
    Vc.getTilesUrl = function (a, b) {
        var c = a.x,
            d = a.y;
        return (Qc[Math.abs(c + d) % Qc.length] + "u=x=" + c + ";y=" + d + ";z=" + b + ";v=009;type=sate&fm=46&udt=20141015").replace(/-(\d+)/gi, "M$1")
    };
    var Xa = new Pc("\u536b\u661f", Vc, {
            tips: "\u663e\u793a\u536b\u661f\u5f71\u50cf",
            minZoom: 1,
            maxZoom: 19,
            textColor: "white"
        }),
        Wc = new Cc({
            transparentPng: o
        });
    Wc.getTilesUrl = function (a, b) {
        var c = a.x,
            d = a.y;
        return (Rc[Math.abs(c + d) % Rc.length] + "?qt=tile&x=" + (c + "").replace(/-/gi, "M") + "&y=" + (d + "").replace(/-/gi, "M") + "&z=" + b + "&styles=sl" + (6 == w.S.ba ? "&color_dep=32&colors=50" : "") + "&udt=20141015").replace(/-(\d+)/gi, "M$1")
    };
    var Qa = new Pc("\u6df7\u5408", [Vc, Wc], {
        tips: "\u663e\u793a\u5e26\u6709\u8857\u9053\u7684\u536b\u661f\u5f71\u50cf",
        labelText: "\u8def\u7f51",
        minZoom: 1,
        maxZoom: 19,
        textColor: "white"
    });
    var Xc = 1,
        S = {};
    window.wZ = S;

    function T(a, b) {
        w.lang.ra.call(this);
        this.gd = {};
        this.Cm(a);
        b = b || {};
        b.aa = b.renderOptions || {};
        this.k = {
            aa: {
                Ca: b.aa.panel || p,
                map: b.aa.map || p,
                Dg: b.aa.autoViewport || o,
                Ss: b.aa.selectFirstResult,
                qs: b.aa.highlightMode,
                Rb: b.aa.enableDragging || q
            },
            mx: b.onSearchComplete || s(),
            PL: b.onMarkersSet || s(),
            OL: b.onInfoHtmlSet || s(),
            RL: b.onResultsHtmlSet || s(),
            NL: b.onGetBusListComplete || s(),
            ML: b.onGetBusLineComplete || s(),
            KL: b.onBusListHtmlSet || s(),
            JL: b.onBusLineHtmlSet || s(),
            XD: b.onPolylinesSet || s(),
            To: b.reqFrom || ""
        };
        this.k.aa.Dg = "undefined" != typeof b && "undefined" != typeof b.renderOptions && "undefined" != typeof b.renderOptions.autoViewport ? b.renderOptions.autoViewport : o;
        this.k.aa.Ca = w.tc(this.k.aa.Ca)
    }
    w.ja(T, w.lang.ra);
    w.extend(T.prototype, {
        getResults: function () {
            return this.vc ? this.pi : this.$
        },
        enableAutoViewport: function () {
            this.k.aa.Dg = o
        },
        disableAutoViewport: function () {
            this.k.aa.Dg = q
        },
        Cm: function (a) {
            a && (this.gd.src = a)
        },
        DE: function (a) {
            this.k.mx = a || s()
        },
        setMarkersSetCallback: function (a) {
            this.k.PL = a || s()
        },
        setPolylinesSetCallback: function (a) {
            this.k.XD = a || s()
        },
        setInfoHtmlSetCallback: function (a) {
            this.k.OL = a || s()
        },
        setResultsHtmlSetCallback: function (a) {
            this.k.RL = a || s()
        },
        Vl: u("jd")
    });
    var Yc = {
        zF: z.wc,
        fb: function (a, b, c, d, e) {
            var f = (1E5 * Math.random()).toFixed(0);
            z._rd["_cbk" + f] = function (b) {
                c = c || {};
                a && a(b, c);
                delete z._rd["_cbk" + f]
            };
            d = d || "";
            b = c && c.lN ? Fb(b, encodeURI) : Fb(b, encodeURIComponent);
            this.zF = c && c.Vr ? c.lM ? c.lM : z.Jo : z.wc;
            d = this.zF + d + "?" + b + "&ie=utf-8&oue=1&fromproduct=jsapi";
            e || (d += "&res=api");
            Qb(d + ("&callback=BMap._rd._cbk" + f))
        }
    };
    window.DZ = Yc;
    z._rd = {};
    var N = {};
    window.CZ = N;
    N.hM = function (a) {
        return a.replace(/<\/?b>/g, "")
    };
    N.gX = function (a) {
        return a.replace(/([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0|[1-9]\d*),([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0|[1-9]\d*)(,)/g, "$1,$2;")
    };
    N.hX = function (a, b) {
        return a.replace(RegExp("(((-?\\d+)(\\.\\d+)?),((-?\\d+)(\\.\\d+)?);)(((-?\\d+)(\\.\\d+)?),((-?\\d+)(\\.\\d+)?);){" + b + "}", "ig"), "$1")
    };
    var Zc = 2,
        $c = 3,
        ad = 0,
        bd = "bt",
        cd = "nav",
        dd = "walk",
        ed = "bl",
        fd = "bsl",
        gd = 14,
        hd = 15,
        id = 18,
        jd = 20,
        kd = 31;
    z.I = window.Instance = w.lang.Md;

    function ld(a, b, c) {
        w.lang.ra.call(this);
        if (a) {
            this.Ia = "object" == typeof a ? a : w.tc(a);
            this.page = 1;
            this.od = 100;
            this.OI = "pg";
            this.Ff = 4;
            this.UI = b;
            this.update = o;
            a = {
                page: 1,
                Ge: 100,
                od: 100,
                Ff: 4,
                OI: "pg",
                update: o
            };
            c || (c = a);
            for (var d in c) "undefined" != typeof c[d] && (this[d] = c[d]);
            this.la()
        }
    }
    w.extend(ld.prototype, {
        la: function () {
            this.fa()
        },
        fa: function () {
            this.HT();
            this.Ia.innerHTML = this.aU()
        },
        HT: function () {
            isNaN(parseInt(this.page)) && (this.page = 1);
            isNaN(parseInt(this.od)) && (this.od = 1);
            1 > this.page && (this.page = 1);
            1 > this.od && (this.od = 1);
            this.page > this.od && (this.page = this.od);
            this.page = parseInt(this.page);
            this.od = parseInt(this.od)
        },
        r0: function () {
            location.search.match(RegExp("[?&]?" + this.OI + "=([^&]*)[&$]?", "gi"));
            this.page = RegExp.$1
        },
        aU: function () {
            var a = [],
                b = this.page - 1,
                c = this.page + 1;
            a.push('<p style="margin:0;padding:0;white-space:nowrap">');
            if (!(1 > b)) {
                if (this.page >= this.Ff) {
                    var d;
                    a.push('<span style="margin-right:3px"><a style="color:#7777cc" href="javascript:void(0)" onclick="{temp1}">\u9996\u9875</a></span>'.replace("{temp1}", "BMap.I('" + this.Q + "').toPage(1);"))
                }
                a.push('<span style="margin-right:3px"><a style="color:#7777cc" href="javascript:void(0)" onclick="{temp2}">\u4e0a\u4e00\u9875</a></span>'.replace("{temp2}", "BMap.I('" + this.Q + "').toPage(" + b + ");"))
            }
            if (this.page < this.Ff) d = 0 == this.page % this.Ff ? this.page - this.Ff - 1 : this.page - this.page % this.Ff + 1, b = d + this.Ff - 1;
            else {
                d = Math.floor(this.Ff / 2);
                var e = this.Ff % 2 - 1,
                    b = this.od > this.page + d ? this.page + d : this.od;
                d = this.page - d - e
            }
            this.page > this.od - this.Ff && this.page >= this.Ff && (d = this.od - this.Ff + 1, b = this.od);
            for (e = d; e <= b; e++) 0 < e && (e == this.page ? a.push('<span style="margin-right:3px">' + e + "</span>") : 1 <= e && e <= this.od && (d = '<span><a style="color:#7777cc;margin-right:3px" href="javascript:void(0)" onclick="{temp3}">[' + e + "]</a></span>", a.push(d.replace("{temp3}", "BMap.I('" + this.Q + "').toPage(" + e + ");"))));
            c > this.od || a.push('<span><a style="color:#7777cc" href="javascript:void(0)" onclick="{temp4}">\u4e0b\u4e00\u9875</a></span>'.replace("{temp4}", "BMap.I('" + this.Q + "').toPage(" + c + ");"));
            a.push("</p>");
            return a.join("")
        },
        toPage: function (a) {
            a = a ? a : 1;
            "function" == typeof this.UI && (this.UI(a), this.page = a);
            this.update && this.la()
        }
    });

    function bb(a, b) {
        T.call(this, a, b);
        b = b || {};
        b.renderOptions = b.renderOptions || {};
        this.ep(b.pageCapacity);
        "undefined" != typeof b.renderOptions.selectFirstResult && !b.renderOptions.selectFirstResult ? this.WB() : this.tC();
        this.ka = [];
        this.bf = [];
        this.La = -1;
        this.Na = [];
        var c = this;
        I.load("local", function () {
            c.Oy()
        }, o)
    }
    w.ja(bb, T, "LocalSearch");
    bb.wp = 10;
    bb.AZ = 1;
    bb.Rm = 100;
    bb.oF = 2E3;
    bb.wF = 1E5;
    w.extend(bb.prototype, {
        search: function (a, b) {
            this.Na.push({
                method: "search",
                arguments: [a, b]
            })
        },
        zm: function (a, b, c) {
            this.Na.push({
                method: "searchInBounds",
                arguments: [a, b, c]
            })
        },
        $o: function (a, b, c, d) {
            this.Na.push({
                method: "searchNearby",
                arguments: [a, b, c, d]
            })
        },
        ze: function () {
            delete this.ta;
            delete this.jd;
            delete this.$;
            delete this.T;
            this.La = -1;
            this.gb();
            this.k.aa.Ca && (this.k.aa.Ca.innerHTML = "")
        },
        Zl: s(),
        tC: function () {
            this.k.aa.Ss = o
        },
        WB: function () {
            this.k.aa.Ss = q
        },
        ep: function (a) {
            this.k.ik = "number" == typeof a && !isNaN(a) ? 1 > a ? bb.wp : a > bb.Rm ? bb.wp : a : bb.wp
        },
        Ve: function () {
            return this.k.ik
        },
        toString: da("LocalSearch")
    });
    var md = bb.prototype;
    U(md, {
        clearResults: md.ze,
        setPageCapacity: md.ep,
        getPageCapacity: md.Ve,
        gotoPage: md.Zl,
        searchNearby: md.$o,
        searchInBounds: md.zm,
        search: md.search,
        enableFirstResultSelection: md.tC,
        disableFirstResultSelection: md.WB
    });

    function nd(a, b) {
        T.call(this, a, b)
    }
    w.ja(nd, T, "BaseRoute");
    w.extend(nd.prototype, {
        ze: s()
    });

    function od(a, b) {
        T.call(this, a, b);
        b = b || {};
        this.$s(b.policy);
        this.ep(b.pageCapacity);
        this.dd = bd;
        this.Qt = gd;
        this.Rt = Xc;
        this.ka = [];
        this.La = -1;
        this.k.Sc = b.enableTraffic || q;
        this.Na = [];
        var c = this;
        I.load("route", function () {
            c.ke()
        })
    }
    od.Rm = 100;
    od.QN = [0, 1, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 1, 1, 1];
    w.ja(od, nd, "TransitRoute");
    w.extend(od.prototype, {
        $s: function (a) {
            this.k.Oc = 0 <= a && 4 >= a ? a : 0
        },
        Oz: function (a, b) {
            this.Na.push({
                method: "_internalSearch",
                arguments: [a, b]
            })
        },
        search: function (a, b) {
            this.Na.push({
                method: "search",
                arguments: [a, b]
            })
        },
        ep: function (a) {
            if ("string" == typeof a && (a = parseInt(a), isNaN(a))) {
                this.k.ik = od.Rm;
                return
            }
            this.k.ik = "number" != typeof a ? od.Rm : 1 <= a && a <= od.Rm ? Math.round(a) : od.Rm
        },
        toString: da("TransitRoute"),
        zS: function (a) {
            return a.replace(/\(.*\)/, "")
        }
    });
    var pd = od.prototype;
    U(pd, {
        _internalSearch: pd.Oz
    });

    function qd(a, b) {
        T.call(this, a, b);
        this.ka = [];
        this.La = -1;
        this.Na = [];
        var c = this,
            d = this.k.aa;
        1 != d.qs && 2 != d.qs && (d.qs = 1);
        this.iz = this.k.aa.Rb ? o : q;
        I.load("route", function () {
            c.ke()
        });
        this.vD && this.vD()
    }
    qd.cO = " \u73af\u5c9b \u65e0\u5c5e\u6027\u9053\u8def \u4e3b\u8def \u9ad8\u901f\u8fde\u63a5\u8def \u4ea4\u53c9\u70b9\u5185\u8def\u6bb5 \u8fde\u63a5\u9053\u8def \u505c\u8f66\u573a\u5185\u90e8\u9053\u8def \u670d\u52a1\u533a\u5185\u90e8\u9053\u8def \u6865 \u6b65\u884c\u8857 \u8f85\u8def \u531d\u9053 \u5168\u5c01\u95ed\u9053\u8def \u672a\u5b9a\u4e49\u4ea4\u901a\u533a\u57df POI\u8fde\u63a5\u8def \u96a7\u9053 \u6b65\u884c\u9053 \u516c\u4ea4\u4e13\u7528\u9053 \u63d0\u524d\u53f3\u8f6c\u9053".split(" ");
    w.ja(qd, nd, "DWRoute");
    w.extend(qd.prototype, {
        search: function (a, b, c) {
            this.Na.push({
                method: "search",
                arguments: [a, b, c]
            })
        }
    });

    function rd(a, b) {
        qd.call(this, a, b);
        b = b || {};
        this.k.Sc = b.enableTraffic || q;
        this.$s(b.policy);
        this.dd = cd;
        this.Qt = jd;
        this.Rt = $c
    }
    w.ja(rd, qd, "DrivingRoute");
    rd.prototype.$s = function (a) {
        this.k.Oc = 0 <= a && 2 >= a ? a : 0
    };

    function sd(a, b) {
        qd.call(this, a, b);
        this.dd = dd;
        this.Qt = kd;
        this.Rt = Zc;
        this.iz = q
    }
    w.ja(sd, qd, "WalkingRoute");

    function td(a, b) {
        w.lang.ra.call(this);
        this.Df = [];
        this.sm = [];
        this.k = b;
        this.Sb = a;
        this.map = this.k.aa.map || p;
        this.Dx = this.k.Dx;
        this.kb = p;
        this.Mi = 0;
        this.Rx = "";
        this.Kd = 1;
        this.rw = "";
        this.Uo = [0, 0, 0, 0, 0, 0, 0];
        this.MD = [];
        this.Br = [1, 1, 1, 1, 1, 1, 1];
        this.aN = [1, 1, 1, 1, 1, 1, 1];
        this.Qs = [0, 0, 0, 0, 0, 0, 0];
        this.Vo = [0, 0, 0, 0, 0, 0, 0];
        this.Ba = [{
            o: "",
            vf: 0,
            Km: 0,
            x: 0,
            y: 0,
            nc: -1
        }, {
            o: "",
            vf: 0,
            Km: 0,
            x: 0,
            y: 0,
            nc: -1
        }, {
            o: "",
            vf: 0,
            Km: 0,
            x: 0,
            y: 0,
            nc: -1
        }, {
            o: "",
            vf: 0,
            Km: 0,
            x: 0,
            y: 0,
            nc: -1
        }, {
            o: "",
            vf: 0,
            Km: 0,
            x: 0,
            y: 0,
            nc: -1
        }, {
            o: "",
            vf: 0,
            Km: 0,
            x: 0,
            y: 0,
            nc: -1
        }, {
            o: "",
            vf: 0,
            Km: 0,
            x: 0,
            y: 0,
            nc: -1
        }];
        this.Mh = -1;
        this.wt = [];
        this.xt = [];
        I.load("route", s())
    }
    w.lang.ja(td, w.lang.ra, "RouteAddr");

    function ud(a) {
        this.k = {};
        w.extend(this.k, a);
        this.Na = [];
        var b = this;
        I.load("othersearch", function () {
            b.ke()
        })
    }
    w.ja(ud, w.lang.ra, "Geocoder");
    w.extend(ud.prototype, {
        Ul: function (a, b, c) {
            this.Na.push({
                method: "getPoint",
                arguments: [a, b, c]
            })
        },
        cs: function (a, b, c) {
            this.Na.push({
                method: "getLocation",
                arguments: [a, b, c]
            })
        },
        toString: da("Geocoder")
    });
    var vd = ud.prototype;
    U(vd, {
        getPoint: vd.Ul,
        getLocation: vd.cs
    });

    function Geolocation(a) {
        a = a || {};
        this.D = {
            timeout: a.timeout || 1E4,
            maximumAge: a.maximumAge || 6E5
        };
        this.Yd = [];
        var b = this;
        I.load("othersearch", function () {
            for (var a = 0, d; d = b.Yd[a]; a++) b[d.method].apply(b, d.arguments)
        })
    }
    w.extend(Geolocation.prototype, {
        getCurrentPosition: function (a, b) {
            this.Yd.push({
                method: "getCurrentPosition",
                arguments: arguments
            })
        },
        getStatus: da(2)
    });

    function wd(a) {
        a = a || {};
        a.aa = a.renderOptions || {};
        this.k = {
            aa: {
                map: a.aa.map || p
            }
        };
        this.Na = [];
        var b = this;
        I.load("othersearch", function () {
            b.ke()
        })
    }
    w.ja(wd, w.lang.ra, "LocalCity");
    w.extend(wd.prototype, {
        get: function (a) {
            this.Na.push({
                method: "get",
                arguments: [a]
            })
        },
        toString: da("LocalCity")
    });

    function xd() {
        this.Na = [];
        var a = this;
        I.load("othersearch", function () {
            a.ke()
        })
    }
    w.ja(xd, w.lang.ra, "Boundary");
    w.extend(xd.prototype, {
        get: function (a, b) {
            this.Na.push({
                method: "get",
                arguments: [a, b]
            })
        },
        toString: da("Boundary")
    });

    function yd(a, b) {
        T.call(this, a, b);
        this.$N = ed;
        this.bO = hd;
        this.ZN = fd;
        this.aO = id;
        this.Na = [];
        var c = this;
        I.load("buslinesearch", function () {
            c.ke()
        })
    }
    yd.Eu = E.ea + "iw_plus.gif";
    yd.RQ = E.ea + "iw_minus.gif";
    yd.JS = E.ea + "stop_icon.png";
    w.ja(yd, T);
    w.extend(yd.prototype, {
        getBusList: function (a) {
            this.Na.push({
                method: "getBusList",
                arguments: [a]
            })
        },
        getBusLine: function (a) {
            this.Na.push({
                method: "getBusLine",
                arguments: [a]
            })
        },
        setGetBusListCompleteCallback: function (a) {
            this.k.NL = a || s()
        },
        setGetBusLineCompleteCallback: function (a) {
            this.k.ML = a || s()
        },
        setBusListHtmlSetCallback: function (a) {
            this.k.KL = a || s()
        },
        setBusLineHtmlSetCallback: function (a) {
            this.k.JL = a || s()
        },
        setPolylinesSetCallback: function (a) {
            this.k.XD = a || s()
        }
    });

    function zd(a) {
        T.call(this, a);
        a = a || {};
        this.oc = {
            input: a.input || p,
            fB: a.baseDom || p,
            types: a.types || [],
            mx: a.onSearchComplete || s()
        };
        this.gd.src = a.location || "\u5168\u56fd";
        this.Ii = "";
        this.Wf = p;
        this.WG = "";
        this.wi();
        Pa(Ia);
        var b = this;
        I.load("autocomplete", function () {
            b.ke()
        })
    }
    w.ja(zd, T, "Autocomplete");
    w.extend(zd.prototype, {
        wi: s(),
        show: s(),
        J: s(),
        EE: function (a) {
            this.oc.types = a
        },
        Cm: function (a) {
            this.gd.src = a
        },
        search: ba("Ii"),
        Gx: ba("WG")
    });
    var Sa;

    function Na(a, b) {
        this.A = "string" == typeof a ? w.N(a) : a;
        this.k = {
            enableScrollWheelZoom: o,
            panoramaRenderer: "flash",
            swfSrc: z.cg("main_domain_nocdn", "res/swf/") + "APILoader.swf",
            visible: o,
            linksControl: o,
            clickOnRoad: o,
            navigationControl: o,
            closeControl: o,
            indoorSceneSwitchControl: o,
            albumsControl: q,
            albumsControlOptions: {},
            copyrightControlOptions: {}
        };
        var b = b || {},
            c;
        for (c in b) this.k[c] = b[c];
        this.ya = {
            heading: 0,
            pitch: 0
        };
        this.un = [];
        this.xb = this.Oa = p;
        this.Vq = this.xj();
        this.ka = [];
        this.Ac = 1;
        this.nf = this.nR = this.Ek = "";
        this.se = {};
        this.sf = p;
        this.wg = [];
        this.Lq = [];
        this.Pq = q;
        var d = this;
        "flashRender" === this.xj() ? I.load("panoramaflash", function () {
            d.wi()
        }, o) : I.load("panorama", function () {
            d.rb()
        }, o);
        this.SR(this.A);
        "api" == b.yf ? Pa(Ea) : Pa(Fa);
        this.addEventListener("id_changed", function () {
            Pa(Da, {
                from: b.yf
            })
        })
    }
    var Ad = 4,
        Bd = 1;
    w.lang.ja(Na, w.lang.ra, "Panorama");
    w.extend(Na.prototype, {
        SR: function (a) {
            var b, c;
            b = a.style;
            c = Ua(a).position;
            "absolute" != c && "relative" != c && (b.position = "relative", b.zIndex = 0);
            if ("absolute" === c || "relative" === c)
                if (a = Ua(a).zIndex, !a || "auto" === a) b.zIndex = 0
        },
        nV: u("un"),
        Gb: u("Oa"),
        PV: u("nv"),
        EM: u("nv"),
        V: u("xb"),
        sa: u("ya"),
        U: u("Ac"),
        Kg: u("Ek"),
        t0: function () {
            return this.$Z || []
        },
        p0: u("nR"),
        is: u("nf"),
        Ix: function (a) {
            a !== this.nf && (this.nf = a, this.dispatchEvent(new L("onscene_type_changed")))
        },
        pc: function (a, b, c) {
            "object" === typeof b && (c = b, b = j);
            a != this.Oa && (this.Pk = this.Oa, this.Qk = this.xb, this.Oa = a, this.nf = b || "street", this.xb = p, c && c.pov && this.rd(c.pov))
        },
        ha: function (a) {
            a.$a(this.xb) || (this.Pk = this.Oa, this.Qk = this.xb, this.xb = a, this.Oa = p)
        },
        rd: function (a) {
            a && (this.ya = a, a = this.ya.pitch, "cvsRender" == this.xj() || Cd() ? (90 < a && (a = 90), -90 > a && (a = -90)) : "cssRender" == this.xj() && (45 < a && (a = 45), -45 > a && (a = -45)), this.Pq = o, this.ya.pitch = a)
        },
        Bc: function (a) {
            a != this.Ac && (a > Ad && (a = Ad), a < Bd && (a = Bd), a != this.Ac && (this.Ac = a))
        },
        FA: function () {
            if (this.C)
                for (var a = this.C.bD(), b = 0; b < a.length; b++)(a[b] instanceof R || a[b] instanceof pc) && a[b].point && this.ka.push(a[b])
        },
        AE: ba("C"),
        Zs: function (a) {
            this.sf = a || "none"
        },
        dp: function (a) {
            for (var b in a) {
                if ("object" == typeof a[b])
                    for (var c in a[b]) this.k[b][c] = a[b][c];
                else this.k[b] = a[b];
                switch (b) {
                case "linksControl":
                    this.dispatchEvent(new L("onlinks_visible_changed"));
                    break;
                case "clickOnRoad":
                    this.dispatchEvent(new L("onclickonroad_changed"));
                    break;
                case "navigationControl":
                    this.dispatchEvent(new L("onnavigation_visible_changed"));
                    break;
                case "indoorSceneSwitchControl":
                    this.dispatchEvent(new L("onindoor_default_switch_mode_changed"));
                    break;
                case "albumsControl":
                    this.dispatchEvent(new L("onalbums_visible_changed"));
                    break;
                case "albumsControlOptions":
                    this.dispatchEvent(new L("onalbums_options_changed"));
                    break;
                case "copyrightControlOptions":
                    this.dispatchEvent(new L("oncopyright_options_changed"))
                }
            }
        },
        ck: function () {
            this.Yk.style.visibility = "hidden"
        },
        Mx: function () {
            this.Yk.style.visibility = "visible"
        },
        FU: function () {
            this.k.enableScrollWheelZoom = o
        },
        qU: function () {
            this.k.enableScrollWheelZoom = q
        },
        show: function () {
            this.k.visible = o
        },
        J: function () {
            this.k.visible = q
        },
        xj: function () {
            return Ta() && !G() && "javascript" != this.k.panoramaRenderer ? "flashRender" : !G() && Mb() ? "cvsRender" : "cssRender"
        },
        xa: function (a) {
            this.se[a.Uc] = a
        },
        Hb: function (a) {
            delete this.se[a]
        },
        vK: function () {
            return this.k.visible
        },
        Ph: function () {
            return new K(this.A.clientWidth, this.A.clientHeight)
        },
        Fa: u("A"),
        YJ: function () {
            var a = z.cg("baidumap", "?"),
                b = this.Gb();
            if (b) {
                var b = {
                        panotype: this.is(),
                        heading: this.sa().heading,
                        pitch: this.sa().pitch,
                        pid: b,
                        panoid: b,
                        from: "api"
                    },
                    c;
                for (c in b) a += c + "=" + b[c] + "&"
            }
            return a.slice(0, -1)
        },
        Nw: function () {
            this.dp({
                copyrightControlOptions: {
                    logoVisible: q
                }
            })
        },
        HE: function () {
            this.dp({
                copyrightControlOptions: {
                    logoVisible: o
                }
            })
        },
        $A: function (a) {
            function b(a, b) {
                return function () {
                    a.Lq.push({
                        wL: b,
                        vL: arguments
                    })
                }
            }
            for (var c = a.getPanoMethodList(), d = "", e = 0, f = c.length; e < f; e++) d = c[e], this[d] = b(this, d);
            this.wg.push(a)
        },
        mE: function (a) {
            for (var b = this.wg.length; b--;) this.wg[b] === a && this.wg.splice(b, 1)
        }
    });
    var Dd = Na.prototype;
    U(Dd, {
        setId: Dd.pc,
        setPosition: Dd.ha,
        setPov: Dd.rd,
        setZoom: Dd.Bc,
        setOptions: Dd.dp,
        getId: Dd.Gb,
        getPosition: Dd.V,
        getPov: Dd.sa,
        getZoom: Dd.U,
        getLinks: Dd.nV,
        getBaiduMapUrl: Dd.YJ,
        hideMapLogo: Dd.Nw,
        showMapLogo: Dd.HE,
        enableDoubleClickZoom: Dd.T_,
        disableDoubleClickZoom: Dd.I_,
        enableScrollWheelZoom: Dd.FU,
        disableScrollWheelZoom: Dd.qU,
        show: Dd.show,
        hide: Dd.J,
        addPlugin: Dd.$A,
        removePlugin: Dd.mE,
        getVisible: Dd.vK,
        addOverlay: Dd.xa,
        removeOverlay: Dd.Hb,
        getSceneType: Dd.is,
        setPanoramaPOIType: Dd.Zs
    });
    U(window, {
        BMAP_PANORAMA_POI_HOTEL: "hotel",
        BMAP_PANORAMA_POI_CATERING: "catering",
        BMAP_PANORAMA_POI_MOVIE: "movie",
        BMAP_PANORAMA_POI_TRANSIT: "transit",
        BMAP_PANORAMA_POI_INDOOR_SCENE: "indoor_scene",
        BMAP_PANORAMA_POI_NONE: "none",
        BMAP_PANORAMA_INDOOR_SCENE: "inter",
        BMAP_PANORAMA_STREET_SCENE: "street"
    });

    function Ed() {
        w.lang.ra.call(this);
        this.Uc = "PanoramaOverlay_" + this.Q;
        this.G = p;
        this.Da = o
    }
    w.lang.ja(Ed, w.lang.ra, "PanoramaOverlayBase");
    w.extend(Ed.prototype, {
        q0: u("Uc"),
        fa: function () {
            aa("initialize\u65b9\u6cd5\u672a\u5b9e\u73b0")
        },
        remove: function () {
            aa("remove\u65b9\u6cd5\u672a\u5b9e\u73b0")
        },
        rf: function () {
            aa("_setOverlayProperty\u65b9\u6cd5\u672a\u5b9e\u73b0")
        }
    });

    function Fd(a, b) {
        Ed.call(this);
        var c = {
                position: p,
                altitude: 2,
                displayDistance: o
            },
            b = b || {},
            d;
        for (d in b) c[d] = b[d];
        this.xb = c.position;
        this.rj = a;
        this.Kp = c.altitude;
        this.AP = c.displayDistance
    }
    w.lang.ja(Fd, Ed, "PanoramaLabel");
    w.extend(Fd.prototype, {
        ha: function (a) {
            this.xb = a;
            this.rf("position", a)
        },
        V: u("xb"),
        Pc: function (a) {
            this.rj = a;
            this.rf("content", a)
        },
        Wj: u("rj"),
        wE: function (a) {
            this.Kp = a;
            this.rf("altitude", a)
        },
        lo: u("Kp"),
        sa: function () {
            var a = this.V(),
                b = p,
                c = p;
            this.G && (c = this.G.V());
            if (a && c)
                if (a.$a(c)) b = this.G.sa();
                else {
                    b = {};
                    b.heading = Gd(a.lng - c.lng, a.lat - c.lat) || 0;
                    var a = b,
                        c = this.lo(),
                        d = this.ln();
                    a.pitch = Math.round(180 * (Math.atan(c / d) / Math.PI)) || 0
                }
            return b
        },
        ln: function () {
            var a = 0,
                b, c;
            this.G && (b = this.G.V(), (c = this.V()) && !c.$a(b) && (a = Q.oo(b, c)));
            return a
        },
        J: function () {
            aa("hide\u65b9\u6cd5\u672a\u5b9e\u73b0")
        },
        show: function () {
            aa("show\u65b9\u6cd5\u672a\u5b9e\u73b0")
        },
        rf: s()
    });
    var Hd = Fd.prototype;
    U(Hd, {
        setPosition: Hd.ha,
        getPosition: Hd.V,
        setContent: Hd.Pc,
        getContent: Hd.Wj,
        setAltitude: Hd.wE,
        getAltitude: Hd.lo,
        getPov: Hd.sa,
        show: Hd.show,
        hide: Hd.J
    });

    function Id(a, b) {
        Ed.call(this);
        var c = {
                icon: "",
                title: "",
                panoInfo: p,
                altitude: 2
            },
            b = b || {},
            d;
        for (d in b) c[d] = b[d];
        this.xb = a;
        this.RG = c.icon;
        this.iI = c.title;
        this.Kp = c.altitude;
        this.ER = c.panoInfo;
        this.ya = {
            heading: 0,
            pitch: 0
        }
    }
    w.lang.ja(Id, Ed, "PanoramaMarker");
    w.extend(Id.prototype, {
        ha: function (a) {
            this.xb = a;
            this.rf("position", a)
        },
        V: u("xb"),
        qc: function (a) {
            this.iI = a;
            this.rf("title", a)
        },
        xo: u("iI"),
        Ob: function (a) {
            this.RG = icon;
            this.rf("icon", a)
        },
        po: u("RG"),
        wE: function (a) {
            this.Kp = a;
            this.rf("altitude", a)
        },
        lo: u("Kp"),
        cD: u("ER"),
        sa: function () {
            var a = p;
            if (this.G) {
                var a = this.G.V(),
                    b = this.V(),
                    a = Gd(b.lng - a.lng, b.lat - a.lat);
                isNaN(a) && (a = 0);
                a = {
                    heading: a,
                    pitch: 0
                }
            } else a = this.ya;
            return a
        },
        rf: s()
    });
    var Jd = Id.prototype;
    U(Jd, {
        setPosition: Jd.ha,
        getPosition: Jd.V,
        setTitle: Jd.qc,
        getTitle: Jd.xo,
        setAltitude: Jd.wE,
        getAltitude: Jd.lo,
        getPanoInfo: Jd.cD,
        getIcon: Jd.po,
        setIcon: Jd.Ob,
        getPov: Jd.sa
    });

    function Gd(a, b) {
        var c = 0;
        if (0 !== a && 0 !== b) {
            var c = 180 * (Math.atan(a / b) / Math.PI),
                d = 0;
            0 < a && 0 > b && (d = 90);
            0 > a && 0 > b && (d = 180);
            0 > a && 0 < b && (d = 270);
            c = (c + 90) % 90 + d
        } else 0 === a ? c = 0 > b ? 180 : 0 : 0 === b && (c = 0 < a ? 90 : 270);
        return Math.round(c)
    }

    function Cd() {
        if ("boolean" === typeof Kd) return Kd;
        if (!window.WebGLRenderingContext || w.platform.ek && -1 == navigator.userAgent.indexOf("Android 5")) return Kd = q;
        var a = document.createElement("canvas"),
            b = p;
        try {
            b = a.getContext("webgl")
        } catch (c) {
            Kd = q
        }
        return Kd = b === p ? q : o
    }
    var Kd;

    function ac(a, b) {
        this.G = a || p;
        var c = this;
        c.G && c.P();
        I.load("pservice", function () {
            c.TO()
        });
        "api" == (b || {}).yf ? Pa(Ga) : Pa(Ha);
        this.ed = {
            getPanoramaById: [],
            getPanoramaByLocation: [],
            getVisiblePOIs: [],
            getRecommendPanosById: [],
            getPanoramaVersions: [],
            checkPanoSupportByCityCode: [],
            getPanoramaByPOIId: [],
            getCopyrightProviders: []
        }
    }
    z.rm(function (a) {
        "flashRender" !== a.xj() && new ac(a, {
            yf: "api"
        })
    });
    w.extend(ac.prototype, {
        P: function () {
            function a(a) {
                if (a) {
                    if (a.id != b.nv) {
                        b.EM(a.id);
                        b.R = a;
                        b.Oa != p && (b.Qk = b._position);
                        for (var c in a)
                            if (a.hasOwnProperty(c)) switch (b["_" + c] = a[c], c) {
                            case "position":
                                b.xb = a[c];
                                break;
                            case "id":
                                b.Oa = a[c];
                                break;
                            case "links":
                                b.un = a[c];
                                break;
                            case "zoom":
                                b.Ac = a[c]
                            }
                            if (b.Qk) {
                                var f = b.Qk,
                                    g = b._position;
                                c = f.lat;
                                var i = g.lat,
                                    k = Nb(i - c),
                                    f = Nb(g.lng - f.lng);
                                c = Math.sin(k / 2) * Math.sin(k / 2) + Math.cos(Nb(c)) * Math.cos(Nb(i)) * Math.sin(f / 2) * Math.sin(f / 2);
                                b.iG = 6371E3 * 2 * Math.atan2(Math.sqrt(c), Math.sqrt(1 - c))
                            }
                        c = new L("ondataload");
                        c.data = a;
                        b.dispatchEvent(c);
                        b.dispatchEvent(new L("onposition_changed"));
                        b.dispatchEvent(new L("onlinks_changed"));
                        b.dispatchEvent(new L("oncopyright_changed"), {
                            copyright: a.copyright
                        });
                        a.Al && b.k.closeControl ? w.B.show(b.qu) : w.B.J(b.qu)
                    }
                } else b.Oa = b.Pk, b.xb = b.Qk, b.dispatchEvent(new L("onnoresult"))
            }
            var b = this.G,
                c = this;
            b.addEventListener("id_changed", function () {
                c.to(b.Gb(), a)
            });
            b.addEventListener("iid_changed", function () {
                c.Ch(ac.Sm + "qt=idata&iid=" + b.Ez + "&fn=", function (b) {
                    if (b && b.result && 0 == b.result.error) {
                        var b = b.content[0].interinfo,
                            e = {};
                        e.Al = b.BreakID;
                        for (var f = b.Defaultfloor, g = p, i = 0; i < b.Floors.length; i++)
                            if (b.Floors[i].Floor == f) {
                                g = b.Floors[i];
                                break
                            }
                        e.id = g.StartID || g.Points[0].PID;
                        c.to(e.id, a, e)
                    }
                })
            });
            b.addEventListener("position_changed_inner", function () {
                c.Wi(b.V(), a)
            })
        },
        to: function (a, b) {
            this.ed.getPanoramaById.push(arguments)
        },
        Wi: function (a, b, c) {
            this.ed.getPanoramaByLocation.push(arguments)
        },
        kD: function (a, b, c, d) {
            this.ed.getVisiblePOIs.push(arguments)
        },
        Iw: function (a, b) {
            this.ed.getRecommendPanosById.push(arguments)
        },
        Hw: function (a) {
            this.ed.getPanoramaVersions.push(arguments)
        },
        oB: function (a, b) {
            this.ed.checkPanoSupportByCityCode.push(arguments)
        },
        Gw: function (a, b) {
            this.ed.getPanoramaByPOIId.push(arguments)
        },
        bK: function (a) {
            this.ed.getCopyrightProviders.push(arguments)
        }
    });
    var Ld = ac.prototype;
    U(Ld, {
        getPanoramaById: Ld.to,
        getPanoramaByLocation: Ld.Wi,
        getPanoramaByPOIId: Ld.Gw
    });

    function $b(a) {
        Cc.call(this);
        "api" == (a || {}).yf ? Pa(Ba) : Pa(Ca)
    }
    $b.DF = z.cg("pano", "tile/");
    $b.prototype = new Cc;
    $b.prototype.getTilesUrl = function (a, b) {
        var c = $b.DF[(a.x + a.y) % $b.DF.length] + "?udt=20150114&qt=tile&styles=pl&x=" + a.x + "&y=" + a.y + "&z=" + b;
        w.S.ba && 6 >= w.S.ba && (c += "&color_dep=32");
        return c
    };
    $b.prototype.As = da(o);
    Md.Dd = new Q;

    function Md() {}
    w.extend(Md, {
        rU: function (a, b, c) {
            c = w.lang.Md(c);
            b = {
                data: b
            };
            "position_changed" == a && (b.data = Md.Dd.bi(new P(b.data.mercatorX, b.data.mercatorY)));
            c.dispatchEvent(new L("on" + a), b)
        }
    });
    var Nd = Md;
    U(Nd, {
        dispatchFlashEvent: Nd.rU
    });
    var Od = {
        SN: 50
    };
    Od.St = z.cg("pano")[0];
    Od.Ot = {
        width: 220,
        height: 60
    };
    w.extend(Od, {
        Eo: function (a, b, c, d) {
            if (!b || !c || !c.lngLat || !c.panoInstance) d();
            else {
                this.zn === j && (this.zn = new ac(p, {
                    yf: "api"
                }));
                var e = this;
                this.zn.oB(b, function (b) {
                    b ? e.zn.Wi(c.lngLat, Od.SN, function (b) {
                        if (b && b.id) {
                            var f = b.id,
                                k = b.Yg,
                                b = b.Zg,
                                l = ac.Dd.Sg(c.lngLat),
                                m = e.vQ(l, {
                                    x: k,
                                    y: b
                                }),
                                k = e.kK(f, m, 0, Od.Ot.width, Od.Ot.height);
                            a.content = e.wQ(a.content, k, c.titleTip, c.beforeDomId);
                            a.addEventListener("open", function () {
                                ja.F(w.tc("infoWndPano"), "click", function () {
                                    c.panoInstance.pc(f);
                                    c.panoInstance.show();
                                    c.panoInstance.rd({
                                        heading: m,
                                        pitch: 0
                                    })
                                })
                            })
                        }
                        d()
                    }) : d()
                })
            }
        },
        wQ: function (a, b, c, d) {
            var c = c || "",
                e;
            !d || !a.split(d)[0] ? (d = a, a = "") : (d = a.split(d)[0], e = d.lastIndexOf("<"), d = a.substring(0, e), a = a.substring(e));
            e = [];
            var f = Od.Ot.width,
                g = Od.Ot.height;
            e.push(d);
            e.push("<div id='infoWndPano' class='panoInfoBox' style='height:" + g + "px;width:" + f + "px; margin-top: -19px;'>");
            e.push("<img class='pano_thumnail_img' width='" + f + "' height='" + g + "' border='0' alt='" + c + "\u5916\u666f' title='" + c + "\u5916\u666f' src='" + b + "' onerror='Pano.PanoEntranceUtil.thumbnailNotFound(this, " + f + ", " + g + ");' />");
            e.push("<div class='panoInfoBoxTitleBg' style='width:" + f + "px;'></div><a href='javascript:void(0)' class='panoInfoBoxTitleContent' >\u8fdb\u5165\u5168\u666f&gt;&gt;</a>");
            e.push("</div>");
            e.push(a);
            return e.join("")
        },
        vQ: function (a, b) {
            var c = 90 - 180 * Math.atan2(a.y - b.y, a.x - b.x) / Math.PI;
            0 > c && (c += 360);
            return c
        },
        kK: function (a, b, c, d, e) {
            var f = {
                panoId: a,
                panoHeading: b || 0,
                panoPitch: c || 0,
                width: d,
                height: e
            };
            return (Od.St + "?qt=pr3d&fovy=75&quality=80&panoid={panoId}&heading={panoHeading}&pitch={panoPitch}&width={width}&height={height}").replace(/\{(.*?)\}/g, function (a, b) {
                return f[b]
            })
        }
    });
    var Pd = document,
        Qd = Math,
        Rd = Pd.createElement("div").style,
        Sd;
    a: {
        for (var Td = ["t", "webkitT", "MozT", "msT", "OT"], Ud, Vd = 0, Xd = Td.length; Vd < Xd; Vd++)
            if (Ud = Td[Vd] + "ransform", Ud in Rd) {
                Sd = Td[Vd].substr(0, Td[Vd].length - 1);
                break a
            }
        Sd = q
    }
    var Yd = Sd ? "-" + Sd.toLowerCase() + "-" : "",
        $d = Zd("transform"),
        ae = Zd("transitionProperty"),
        be = Zd("transitionDuration"),
        ce = Zd("transformOrigin"),
        de = Zd("transitionTimingFunction"),
        ee = Zd("transitionDelay"),
        fe = /android/gi.test(navigator.appVersion),
        ge = /iphone|ipad/gi.test(navigator.appVersion),
        he = /hp-tablet/gi.test(navigator.appVersion),
        ie = Zd("perspective") in Rd,
        je = "ontouchstart" in window && !he,
        ke = Sd !== q,
        le = Zd("transition") in Rd,
        ne = "onorientationchange" in window ? "orientationchange" : "resize",
        oe = je ? "touchstart" : "mousedown",
        pe = je ? "touchmove" : "mousemove",
        qe = je ? "touchend" : "mouseup",
        re = je ? "touchcancel" : "mouseup",
        se = Sd === q ? q : {
            "": "transitionend",
            webkit: "webkitTransitionEnd",
            Moz: "transitionend",
            O: "otransitionend",
            ms: "MSTransitionEnd"
        }[Sd],
        te = window.requestAnimationFrame || window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame || window.oRequestAnimationFrame || window.msRequestAnimationFrame || function (a) {
            return setTimeout(a, 1)
        },
        ue = window.cancelRequestAnimationFrame || window.h2 || window.webkitCancelRequestAnimationFrame || window.mozCancelRequestAnimationFrame || window.oCancelRequestAnimationFrame || window.msCancelRequestAnimationFrame || clearTimeout,
        ve = ie ? " translateZ(0)" : "";

    function we(a, b) {
        var c = this,
            d;
        c.Mm = "object" == typeof a ? a : Pd.getElementById(a);
        c.Mm.style.overflow = "hidden";
        c.Bb = c.Mm.children[0];
        c.options = {
            Bo: o,
            op: o,
            x: 0,
            y: 0,
            ur: o,
            yT: q,
            UD: o,
            nL: o,
            vk: o,
            gi: q,
            LY: 0,
            nB: q,
            nD: o,
            $i: o,
            ij: o,
            DC: fe,
            Ow: ge,
            KU: ge && ie,
            tE: "",
            zoom: q,
            wk: 1,
            rp: 4,
            tU: 2,
            xN: "scroll",
            it: q,
            Px: 1,
            QL: p,
            IL: function (a) {
                a.preventDefault()
            },
            TL: p,
            HL: p,
            SL: p,
            GL: p,
            lx: p,
            UL: p,
            LL: p,
            No: p,
            VL: p,
            Mo: p
        };
        for (d in b) c.options[d] = b[d];
        c.x = c.options.x;
        c.y = c.options.y;
        c.options.vk = ke && c.options.vk;
        c.options.$i = c.options.Bo && c.options.$i;
        c.options.ij = c.options.op && c.options.ij;
        c.options.zoom = c.options.vk && c.options.zoom;
        c.options.gi = le && c.options.gi;
        c.options.zoom && fe && (ve = "");
        c.Bb.style[ae] = c.options.vk ? Yd + "transform" : "top left";
        c.Bb.style[be] = "0";
        c.Bb.style[ce] = "0 0";
        c.options.gi && (c.Bb.style[de] = "cubic-bezier(0.33,0.66,0.66,1)");
        c.options.vk ? c.Bb.style[$d] = "translate(" + c.x + "px," + c.y + "px)" + ve : c.Bb.style.cssText += ";position:absolute;top:" + c.y + "px;left:" + c.x + "px";
        c.options.gi && (c.options.DC = o);
        c.refresh();
        c.P(ne, window);
        c.P(oe);
        !je && "none" != c.options.xN && (c.P("DOMMouseScroll"), c.P("mousewheel"));
        c.options.nB && (c.GT = setInterval(function () {
            c.RO()
        }, 500));
        this.options.nD && (Event.prototype.stopImmediatePropagation || (document.body.removeEventListener = function (a, b, c) {
            var d = Node.prototype.removeEventListener;
            a === "click" ? d.call(document.body, a, b.BK || b, c) : d.call(document.body, a, b, c)
        }, document.body.addEventListener = function (a, b, c) {
            var d = Node.prototype.addEventListener;
            a === "click" ? d.call(document.body, a, b.BK || (b.BK = function (a) {
                a.rX || b(a)
            }), c) : d.call(document.body, a, b, c)
        }), c.P("click", document.body, o))
    }
    we.prototype = {
        enabled: o,
        x: 0,
        y: 0,
        hj: [],
        scale: 1,
        JB: 0,
        KB: 0,
        De: [],
        $e: [],
        eB: p,
        $x: 0,
        handleEvent: function (a) {
            switch (a.type) {
            case oe:
                if (!je && 0 !== a.button) break;
                this.gv(a);
                break;
            case pe:
                this.pR(a);
                break;
            case qe:
            case re:
                this.pu(a);
                break;
            case ne:
                this.yA();
                break;
            case "DOMMouseScroll":
            case "mousewheel":
                this.US(a);
                break;
            case se:
                this.QS(a);
                break;
            case "click":
                this.aP(a)
            }
        },
        RO: function () {
            !this.Wg && (!this.xk && !(this.vl || this.Fx == this.Bb.offsetWidth * this.scale && this.Zo == this.Bb.offsetHeight * this.scale)) && this.refresh()
        },
        Xu: function (a) {
            var b;
            this[a + "Scrollbar"] ? (this[a + "ScrollbarWrapper"] || (b = Pd.createElement("div"), this.options.tE ? b.className = this.options.tE + a.toUpperCase() : b.style.cssText = "position:absolute;z-index:100;" + ("h" == a ? "height:7px;bottom:1px;left:2px;right:" + (this.ij ? "7" : "2") + "px" : "width:7px;bottom:" + (this.$i ? "7" : "2") + "px;top:2px;right:1px"), b.style.cssText += ";pointer-events:none;" + Yd + "transition-property:opacity;" + Yd + "transition-duration:" + (this.options.KU ? "350ms" : "0") + ";overflow:hidden;opacity:" + (this.options.Ow ? "0" : "1"), this.Mm.appendChild(b), this[a + "ScrollbarWrapper"] = b, b = Pd.createElement("div"), this.options.tE || (b.style.cssText = "position:absolute;z-index:100;background:rgba(0,0,0,0.5);border:1px solid rgba(255,255,255,0.9);" + Yd + "background-clip:padding-box;" + Yd + "box-sizing:border-box;" + ("h" == a ? "height:100%" : "width:100%") + ";" + Yd + "border-radius:3px;border-radius:3px"), b.style.cssText += ";pointer-events:none;" + Yd + "transition-property:" + Yd + "transform;" + Yd + "transition-timing-function:cubic-bezier(0.33,0.66,0.66,1);" + Yd + "transition-duration:0;" + Yd + "transform: translate(0,0)" + ve, this.options.gi && (b.style.cssText += ";" + Yd + "transition-timing-function:cubic-bezier(0.33,0.66,0.66,1)"), this[a + "ScrollbarWrapper"].appendChild(b), this[a + "ScrollbarIndicator"] = b), "h" == a ? (this.xK = this.yK.clientWidth, this.XV = Qd.max(Qd.round(this.xK * this.xK / this.Fx), 8), this.WV.style.width = this.XV + "px") : (this.pN = this.qN.clientHeight, this.gZ = Qd.max(Qd.round(this.pN * this.pN / this.Zo), 8), this.fZ.style.height = this.gZ + "px"), this.zA(a, o)) : this[a + "ScrollbarWrapper"] && (ke && (this[a + "ScrollbarIndicator"].style[$d] = ""), this[a + "ScrollbarWrapper"].parentNode.removeChild(this[a + "ScrollbarWrapper"]), this[a + "ScrollbarWrapper"] = p, this[a + "ScrollbarIndicator"] = p)
        },
        yA: function () {
            var a = this;
            setTimeout(function () {
                a.refresh()
            }, fe ? 200 : 0)
        },
        Oq: function (a, b) {
            this.xk || (a = this.Bo ? a : 0, b = this.op ? b : 0, this.options.vk ? this.Bb.style[$d] = "translate(" + a + "px," + b + "px) scale(" + this.scale + ")" + ve : (a = Qd.round(a), b = Qd.round(b), this.Bb.style.left = a + "px", this.Bb.style.top = b + "px"), this.x = a, this.y = b, this.zA("h"), this.zA("v"))
        },
        zA: function (a, b) {
            var c = "h" == a ? this.x : this.y;
            this[a + "Scrollbar"] && (c *= this[a + "ScrollbarProp"], 0 > c ? (this.options.DC || (c = this[a + "ScrollbarIndicatorSize"] + Qd.round(3 * c), 8 > c && (c = 8), this[a + "ScrollbarIndicator"].style["h" == a ? "width" : "height"] = c + "px"), c = 0) : c > this[a + "ScrollbarMaxScroll"] && (this.options.DC ? c = this[a + "ScrollbarMaxScroll"] : (c = this[a + "ScrollbarIndicatorSize"] - Qd.round(3 * (c - this[a + "ScrollbarMaxScroll"])), 8 > c && (c = 8), this[a + "ScrollbarIndicator"].style["h" == a ? "width" : "height"] = c + "px", c = this[a + "ScrollbarMaxScroll"] + (this[a + "ScrollbarIndicatorSize"] - c))), this[a + "ScrollbarWrapper"].style[ee] = "0", this[a + "ScrollbarWrapper"].style.opacity = b && this.options.Ow ? "0" : "1", this[a + "ScrollbarIndicator"].style[$d] = "translate(" + ("h" == a ? c + "px,0)" : "0," + c + "px)") + ve)
        },
        aP: function (a) {
            if (a.UP === o) return this.XA = a.target, this.sw = Date.now(), o;
            if (this.XA && this.sw) {
                if (600 < Date.now() - this.sw) return this.sw = this.XA = p, o
            } else {
                for (var b = a.target; b != this.Bb && b != document.body;) b = b.parentNode;
                if (b == document.body) return o
            }
            for (b = a.target; 1 != b.nodeType;) b = b.parentNode;
            b = b.tagName.toLowerCase();
            if ("select" != b && "input" != b && "textarea" != b) return a.stopImmediatePropagation ? a.stopImmediatePropagation() : a.rX = o, a.stopPropagation(), a.preventDefault(), this.sw = this.XA = p, q
        },
        gv: function (a) {
            var b = je ? a.touches[0] : a,
                c, d;
            if (this.enabled) {
                this.options.IL && this.options.IL.call(this, a);
                (this.options.gi || this.options.zoom) && this.jI(0);
                this.xk = this.vl = this.Wg = q;
                this.TB = this.SB = this.yv = this.xv = this.ZB = this.YB = 0;
                this.options.zoom && (je && 1 < a.touches.length) && (d = Qd.abs(a.touches[0].pageX - a.touches[1].pageX), c = Qd.abs(a.touches[0].pageY - a.touches[1].pageY), this.NY = Qd.sqrt(d * d + c * c), this.nx = Qd.abs(a.touches[0].pageX + a.touches[1].pageX - 2 * this.YE) / 2 - this.x, this.ox = Qd.abs(a.touches[0].pageY + a.touches[1].pageY - 2 * this.ZE) / 2 - this.y, this.options.No && this.options.No.call(this, a));
                if (this.options.UD && (this.options.vk ? (c = getComputedStyle(this.Bb, p)[$d].replace(/[^0-9\-.,]/g, "").split(","), d = +(c[12] || c[4]), c = +(c[13] || c[5])) : (d = +getComputedStyle(this.Bb, p).left.replace(/[^0-9-]/g, ""), c = +getComputedStyle(this.Bb, p).top.replace(/[^0-9-]/g, "")), d != this.x || c != this.y)) this.options.gi ? this.Fd(se) : ue(this.eB), this.hj = [], this.Oq(d, c), this.options.lx && this.options.lx.call(this);
                this.zv = this.x;
                this.Av = this.y;
                this.lt = this.x;
                this.mt = this.y;
                this.Yg = b.pageX;
                this.Zg = b.pageY;
                this.startTime = a.timeStamp || Date.now();
                this.options.TL && this.options.TL.call(this, a);
                this.P(pe, window);
                this.P(qe, window);
                this.P(re, window)
            }
        },
        pR: function (a) {
            var b = je ? a.touches[0] : a,
                c = b.pageX - this.Yg,
                d = b.pageY - this.Zg,
                e = this.x + c,
                f = this.y + d,
                g = a.timeStamp || Date.now();
            this.options.HL && this.options.HL.call(this, a);
            if (this.options.zoom && je && 1 < a.touches.length) e = Qd.abs(a.touches[0].pageX - a.touches[1].pageX), f = Qd.abs(a.touches[0].pageY - a.touches[1].pageY), this.MY = Qd.sqrt(e * e + f * f), this.xk = o, b = 1 / this.NY * this.MY * this.scale, b < this.options.wk ? b = 0.5 * this.options.wk * Math.pow(2, b / this.options.wk) : b > this.options.rp && (b = 2 * this.options.rp * Math.pow(0.5, this.options.rp / b)), this.Ho = b / this.scale, e = this.nx - this.nx * this.Ho + this.x, f = this.ox - this.ox * this.Ho + this.y, this.Bb.style[$d] = "translate(" + e + "px," + f + "px) scale(" + b + ")" + ve, this.options.VL && this.options.VL.call(this, a);
            else {
                this.Yg = b.pageX;
                this.Zg = b.pageY;
                if (0 < e || e < this.Rd) e = this.options.ur ? this.x + c / 2 : 0 <= e || 0 <= this.Rd ? 0 : this.Rd;
                if (f > this.Ye || f < this.Zc) f = this.options.ur ? this.y + d / 2 : f >= this.Ye || 0 <= this.Zc ? this.Ye : this.Zc;
                this.YB += c;
                this.ZB += d;
                this.xv = Qd.abs(this.YB);
                this.yv = Qd.abs(this.ZB);
                6 > this.xv && 6 > this.yv || (this.options.nL && (this.xv > this.yv + 5 ? (f = this.y, d = 0) : this.yv > this.xv + 5 && (e = this.x, c = 0)), this.Wg = o, this.Oq(e, f), this.SB = 0 < c ? -1 : 0 > c ? 1 : 0, this.TB = 0 < d ? -1 : 0 > d ? 1 : 0, 300 < g - this.startTime && (this.startTime = g, this.lt = this.x, this.mt = this.y), this.options.SL && this.options.SL.call(this, a))
            }
        },
        pu: function (a) {
            if (!(je && 0 !== a.touches.length)) {
                var b = this,
                    c = je ? a.changedTouches[0] : a,
                    d, e, f = {
                        oa: 0,
                        time: 0
                    },
                    g = {
                        oa: 0,
                        time: 0
                    },
                    i = (a.timeStamp || Date.now()) - b.startTime;
                d = b.x;
                e = b.y;
                b.Fd(pe, window);
                b.Fd(qe, window);
                b.Fd(re, window);
                b.options.GL && b.options.GL.call(b, a);
                if (b.xk) d = b.scale * b.Ho, d = Math.max(b.options.wk, d), d = Math.min(b.options.rp, d), b.Ho = d / b.scale, b.scale = d, b.x = b.nx - b.nx * b.Ho + b.x, b.y = b.ox - b.ox * b.Ho + b.y, b.Bb.style[be] = "200ms", b.Bb.style[$d] = "translate(" + b.x + "px," + b.y + "px) scale(" + b.scale + ")" + ve, b.xk = q, b.refresh(), b.options.Mo && b.options.Mo.call(b, a);
                else {
                    if (b.Wg) {
                        if (300 > i && b.options.UD) {
                            f = d ? b.hH(d - b.lt, i, -b.x, b.Fx - b.Gt + b.x, b.options.ur ? b.Gt : 0) : f;
                            g = e ? b.hH(e - b.mt, i, -b.y, 0 > b.Zc ? b.Zo - b.Nm + b.y - b.Ye : 0, b.options.ur ? b.Nm : 0) : g;
                            d = b.x + f.oa;
                            e = b.y + g.oa;
                            if (0 < b.x && 0 < d || b.x < b.Rd && d < b.Rd) f = {
                                oa: 0,
                                time: 0
                            };
                            if (b.y > b.Ye && e > b.Ye || b.y < b.Zc && e < b.Zc) g = {
                                oa: 0,
                                time: 0
                            }
                        }
                        f.oa || g.oa ? (c = Qd.max(Qd.max(f.time, g.time), 10), b.options.it && (f = d - b.zv, g = e - b.Av, Qd.abs(f) < b.options.Px && Qd.abs(g) < b.options.Px ? b.scrollTo(b.zv, b.Av, 200) : (f = b.aI(d, e), d = f.x, e = f.y, c = Qd.max(f.time, c))), b.scrollTo(Qd.round(d), Qd.round(e), c)) : b.options.it ? (f = d - b.zv, g = e - b.Av, Qd.abs(f) < b.options.Px && Qd.abs(g) < b.options.Px ? b.scrollTo(b.zv, b.Av, 200) : (f = b.aI(b.x, b.y), (f.x != b.x || f.y != b.y) && b.scrollTo(f.x, f.y, f.time))) : b.Bn(200)
                    } else {
                        if (je)
                            if (b.xJ && b.options.zoom) clearTimeout(b.xJ), b.xJ = p, b.options.No && b.options.No.call(b, a), b.zoom(b.Yg, b.Zg, 1 == b.scale ? b.options.tU : 1), b.options.Mo && setTimeout(function () {
                                b.options.Mo.call(b, a)
                            }, 200);
                            else if (this.options.nD) {
                            for (d = c.target; 1 != d.nodeType;) d = d.parentNode;
                            e = d.tagName.toLowerCase();
                            "select" != e && "input" != e && "textarea" != e ? (e = Pd.createEvent("MouseEvents"), e.initMouseEvent("click", o, o, a.view, 1, c.screenX, c.screenY, c.clientX, c.clientY, a.ctrlKey, a.altKey, a.shiftKey, a.metaKey, 0, p), e.UP = o, d.dispatchEvent(e)) : d.focus()
                        }
                        b.Bn(400)
                    }
                    b.options.UL && b.options.UL.call(b, a)
                }
            }
        },
        Bn: function (a) {
            var b = 0 <= this.x ? 0 : this.x < this.Rd ? this.Rd : this.x,
                c = this.y >= this.Ye || 0 < this.Zc ? this.Ye : this.y < this.Zc ? this.Zc : this.y;
            if (b == this.x && c == this.y) {
                if (this.Wg && (this.Wg = q, this.options.lx && this.options.lx.call(this)), this.$i && this.options.Ow && ("webkit" == Sd && (this.yK.style[ee] = "300ms"), this.yK.style.opacity = "0"), this.ij && this.options.Ow) "webkit" == Sd && (this.qN.style[ee] = "300ms"), this.qN.style.opacity = "0"
            } else this.scrollTo(b, c, a || 0)
        },
        US: function (a) {
            var b = this,
                c, d;
            if ("wheelDeltaX" in a) c = a.wheelDeltaX / 12, d = a.wheelDeltaY / 12;
            else if ("wheelDelta" in a) c = d = a.wheelDelta / 12;
            else if ("detail" in a) c = d = 3 * -a.detail;
            else return;
            if ("zoom" == b.options.xN) {
                if (d = b.scale * Math.pow(2, 1 / 3 * (d ? d / Math.abs(d) : 0)), d < b.options.wk && (d = b.options.wk), d > b.options.rp && (d = b.options.rp), d != b.scale) !b.$x && b.options.No && b.options.No.call(b, a), b.$x++, b.zoom(a.pageX, a.pageY, d, 400), setTimeout(function () {
                    b.$x--;
                    !b.$x && b.options.Mo && b.options.Mo.call(b, a)
                }, 400)
            } else c = b.x + c, d = b.y + d, 0 < c ? c = 0 : c < b.Rd && (c = b.Rd), d > b.Ye ? d = b.Ye : d < b.Zc && (d = b.Zc), 0 > b.Zc && b.scrollTo(c, d, 0)
        },
        QS: function (a) {
            a.target == this.Bb && (this.Fd(se), this.LA())
        },
        LA: function () {
            var a = this,
                b = a.x,
                c = a.y,
                d = Date.now(),
                e, f, g;
            a.vl || (a.hj.length ? (e = a.hj.shift(), e.x == b && e.y == c && (e.time = 0), a.vl = o, a.Wg = o, a.options.gi) ? (a.jI(e.time), a.Oq(e.x, e.y), a.vl = q, e.time ? a.P(se) : a.Bn(0)) : (g = function () {
                var i = Date.now(),
                    k;
                if (i >= d + e.time) {
                    a.Oq(e.x, e.y);
                    a.vl = q;
                    a.options.YW && a.options.YW.call(a);
                    a.LA()
                } else {
                    i = (i - d) / e.time - 1;
                    f = Qd.sqrt(1 - i * i);
                    i = (e.x - b) * f + b;
                    k = (e.y - c) * f + c;
                    a.Oq(i, k);
                    if (a.vl) a.eB = te(g)
                }
            }, g()) : a.Bn(400))
        },
        jI: function (a) {
            a += "ms";
            this.Bb.style[be] = a;
            this.$i && (this.WV.style[be] = a);
            this.ij && (this.fZ.style[be] = a)
        },
        hH: function (a, b, c, d, e) {
            var b = Qd.abs(a) / b,
                f = b * b / 0.0012;
            0 < a && f > c ? (c += e / (6 / (6.0E-4 * (f / b))), b = b * c / f, f = c) : 0 > a && f > d && (d += e / (6 / (6.0E-4 * (f / b))), b = b * d / f, f = d);
            return {
                oa: f * (0 > a ? -1 : 1),
                time: Qd.round(b / 6.0E-4)
            }
        },
        Ej: function (a) {
            for (var b = -a.offsetLeft, c = -a.offsetTop; a = a.offsetParent;) b -= a.offsetLeft, c -= a.offsetTop;
            a != this.Mm && (b *= this.scale, c *= this.scale);
            return {
                left: b,
                top: c
            }
        },
        aI: function (a, b) {
            var c, d, e;
            e = this.De.length - 1;
            c = 0;
            for (d = this.De.length; c < d; c++)
                if (a >= this.De[c]) {
                    e = c;
                    break
                }
            e == this.JB && (0 < e && 0 > this.SB) && e--;
            a = this.De[e];
            d = (d = Qd.abs(a - this.De[this.JB])) ? 500 * (Qd.abs(this.x - a) / d) : 0;
            this.JB = e;
            e = this.$e.length - 1;
            for (c = 0; c < e; c++)
                if (b >= this.$e[c]) {
                    e = c;
                    break
                }
            e == this.KB && (0 < e && 0 > this.TB) && e--;
            b = this.$e[e];
            c = (c = Qd.abs(b - this.$e[this.KB])) ? 500 * (Qd.abs(this.y - b) / c) : 0;
            this.KB = e;
            e = Qd.round(Qd.max(d, c)) || 200;
            return {
                x: a,
                y: b,
                time: e
            }
        },
        P: function (a, b, c) {
            (b || this.Bb).addEventListener(a, this, !!c)
        },
        Fd: function (a, b, c) {
            (b || this.Bb).removeEventListener(a, this, !!c)
        },
        PB: ga(2),
        refresh: function () {
            var a, b, c, d = 0;
            b = 0;
            this.scale < this.options.wk && (this.scale = this.options.wk);
            this.Gt = this.Mm.clientWidth || 1;
            this.Nm = this.Mm.clientHeight || 1;
            this.Ye = -this.options.LY || 0;
            this.Fx = Qd.round(this.Bb.offsetWidth * this.scale);
            this.Zo = Qd.round((this.Bb.offsetHeight + this.Ye) * this.scale);
            this.Rd = this.Gt - this.Fx;
            this.Zc = this.Nm - this.Zo + this.Ye;
            this.TB = this.SB = 0;
            this.options.QL && this.options.QL.call(this);
            this.Bo = this.options.Bo && 0 > this.Rd;
            this.op = this.options.op && (!this.options.yT && !this.Bo || this.Zo > this.Nm);
            this.$i = this.Bo && this.options.$i;
            this.ij = this.op && this.options.ij && this.Zo > this.Nm;
            a = this.Ej(this.Mm);
            this.YE = -a.left;
            this.ZE = -a.top;
            if ("string" == typeof this.options.it) {
                this.De = [];
                this.$e = [];
                c = this.Bb.querySelectorAll(this.options.it);
                a = 0;
                for (b = c.length; a < b; a++) d = this.Ej(c[a]), d.left += this.YE, d.top += this.ZE, this.De[a] = d.left < this.Rd ? this.Rd : d.left * this.scale, this.$e[a] = d.top < this.Zc ? this.Zc : d.top * this.scale
            } else if (this.options.it) {
                for (this.De = []; d >= this.Rd;) this.De[b] = d, d -= this.Gt, b++;
                this.Rd % this.Gt && (this.De[this.De.length] = this.Rd - this.De[this.De.length - 1] + this.De[this.De.length - 1]);
                b = d = 0;
                for (this.$e = []; d >= this.Zc;) this.$e[b] = d, d -= this.Nm, b++;
                this.Zc % this.Nm && (this.$e[this.$e.length] = this.Zc - this.$e[this.$e.length - 1] + this.$e[this.$e.length - 1])
            }
            this.Xu("h");
            this.Xu("v");
            this.xk || (this.Bb.style[be] = "0", this.Bn(400))
        },
        scrollTo: function (a, b, c, d) {
            var e = a;
            this.stop();
            e.length || (e = [{
                x: a,
                y: b,
                time: c,
                sX: d
            }]);
            a = 0;
            for (b = e.length; a < b; a++) e[a].sX && (e[a].x = this.x - e[a].x, e[a].y = this.y - e[a].y), this.hj.push({
                x: e[a].x,
                y: e[a].y,
                time: e[a].time || 0
            });
            this.LA()
        },
        disable: function () {
            this.stop();
            this.Bn(0);
            this.enabled = q;
            this.Fd(pe, window);
            this.Fd(qe, window);
            this.Fd(re, window)
        },
        enable: function () {
            this.enabled = o
        },
        stop: function () {
            this.options.gi ? this.Fd(se) : ue(this.eB);
            this.hj = [];
            this.vl = this.Wg = q
        },
        zoom: function (a, b, c, d) {
            var e = c / this.scale;
            this.options.vk && (this.xk = o, d = d === j ? 200 : d, a = a - this.YE - this.x, b = b - this.ZE - this.y, this.x = a - a * e + this.x, this.y = b - b * e + this.y, this.scale = c, this.refresh(), this.x = 0 < this.x ? 0 : this.x < this.Rd ? this.Rd : this.x, this.y = this.y > this.Ye ? this.Ye : this.y < this.Zc ? this.Zc : this.y, this.Bb.style[be] = d + "ms", this.Bb.style[$d] = "translate(" + this.x + "px," + this.y + "px) scale(" + c + ")" + ve, this.xk = q)
        }
    };

    function Zd(a) {
        if ("" === Sd) return a;
        a = a.charAt(0).toUpperCase() + a.substr(1);
        return Sd + a
    }
    Rd = p;

    function xe(a) {
        this.k = {
            anchor: Vb,
            offset: new K(0, 0),
            maxWidth: "100%",
            imageHeight: 80
        };
        var a = a || {},
            b;
        for (b in a) this.k[b] = a[b];
        this.hl = new ac(p, {
            yf: "api"
        });
        this.Fj = [];
        this.G = p;
        this.ti = {
            height: this.k.imageHeight,
            width: this.k.imageHeight * ye
        };
        this.gj = this.AA = this.Al = this.Kc = p
    }
    z.rm(function (a) {
        var b = p;
        a.addEventListener("position_changed", function () {
            a.k.albumsControl === o && (b ? b.zx(a.Gb()) : (b = new xe(a.k.albumsControlOptions), b.fa(a)))
        });
        a.addEventListener("albums_visible_changed", function () {
            a.k.albumsControl === o ? (b ? b.zx(a.Gb()) : (b = new xe(a.k.albumsControlOptions), b.fa(a)), b.show()) : b.J()
        });
        a.addEventListener("albums_options_changed", function () {
            b && b.dp(a.k.albumsControlOptions)
        })
    });
    var ye = 1.8;
    w.extend(xe.prototype, {
        dp: function (a) {
            for (var b in a) this.k[b] = a[b];
            a = this.k.imageHeight + "px";
            this.lc(this.k.anchor);
            this.A.style.width = isNaN(Number(this.k.maxWidth)) === o ? this.k.maxWidth : this.k.maxWidth + "px";
            this.A.style.height = a;
            this.Ij.style.height = a;
            this.Dh.style.height = a;
            this.ti = {
                height: this.k.imageHeight,
                width: this.k.imageHeight * ye
            };
            this.Hj.style.height = this.ti.height - 6 + "px";
            this.Hj.style.width = this.ti.width - 6 + "px";
            this.zx(this.G.Gb(), o)
        },
        fa: function (a) {
            this.G = a;
            this.zr();
            this.CO();
            this.jW();
            this.zx(a.Gb())
        },
        zr: function () {
            var a = this.k.imageHeight + "px";
            this.A = J("div");
            var b = this.A.style;
            b.position = "absolute";
            b.zIndex = "2000";
            b.width = isNaN(Number(this.k.maxWidth)) === o ? this.k.maxWidth : this.k.maxWidth + "px";
            b.padding = "8px 0";
            b.background = "white";
            b.visibility = "hidden";
            b.height = a;
            this.Ij = J("div");
            b = this.Ij.style;
            b.position = "absolute";
            b.overflow = "hidden";
            b.width = "100%";
            b.height = a;
            this.Dh = J("div");
            b = this.Dh.style;
            b.height = a;
            this.Ij.appendChild(this.Dh);
            this.A.appendChild(this.Ij);
            this.G.A.appendChild(this.A);
            this.Hj = J("div", {
                "class": "pano_photo_item_seleted"
            });
            this.Hj.style.height = this.ti.height - 6 + "px";
            this.Hj.style.width = this.ti.width - 6 + "px";
            this.lc(this.k.anchor)
        },
        DG: function (a) {
            for (var b = this.Fj, c = b.length - 1; 0 <= c; c--)
                if (b[c].panoId == a) return c;
            return -1
        },
        zx: function (a, b) {
            if (b || !this.Fj[this.Kc] || !(this.Fj[this.Kc].panoId == a && 3 !== this.Fj[this.Kc].recoType)) {
                var c = this,
                    d = this.DG(a);
                !b && -1 !== d && this.Fj[d] && 3 !== this.Fj[d].recoType ? this.cp(d) : this.BV(function (a) {
                    c.Fj = a;
                    c.Tq(a);
                    0 == a.length ? c.J() : c.show()
                })
            }
        },
        Tq: function (a) {
            this.Dh.innerHTML = this.lV(a);
            this.Dh.style.width = (this.ti.width + 8) * a.length + 8 + "px";
            var a = this.A.offsetWidth,
                b = this.Dh.offsetWidth;
            this.gj.Zr && (b += this.gj.Zr());
            b < a ? this.A.style.width = b + "px" : (this.A.style.width = isNaN(Number(this.k.maxWidth)) === o ? this.k.maxWidth : this.k.maxWidth + "px", b < this.A.offsetWidth && (this.A.style.width = b + "px"));
            this.gj.refresh();
            this.AA = this.Dh.children;
            this.Dh.appendChild(this.Hj);
            this.Hj.style.left = "-100000px";
            a = this.DG(this.G.Gb(), this.d_); - 1 !== a && this.cp(a)
        },
        lV: function (a) {
            for (var b, c, d, e, f = [], g = this.ti.height, i = this.ti.width, k = 0; k < a.length; k++) b = a[k], recoType = b.recoType, c = b.panoId, d = b.name, e = b.heading, b = b.pitch, c = Od.kK(c, e, b, 198, 108), f.push('<a href="javascript:void(0);" class="pano_photo_item" data-index="' + k + '"><img style="width:' + (i - 2) + "px;height:" + (g - 2) + 'px;" data-index="' + k + '" name="' + d + '" src="' + c + '" alt="' + d + '"/><span class="pano_photo_decs" data-index="' + k + '" style="width:' + i + "px;font-size:" + Math.floor(g / 6) + "px; line-height:" + Math.floor(g / 6) + 'px;"><em class="pano_poi_' + recoType + '"></em>' + d + "</span></a>");
            return f.join("")
        },
        BV: function (a) {
            var b = this,
                c = this.G.Gb();
            this.hl.Iw(c, function (d) {
                b.G.Gb() === c && a(d)
            })
        },
        lc: function (a) {
            if (!Va(a) || isNaN(a) || a < Tb || 3 < a) a = this.defaultAnchor;
            var b = this.A,
                c = this.k.offset.width,
                d = this.k.offset.height;
            b.style.left = b.style.top = b.style.right = b.style.bottom = "auto";
            switch (a) {
            case Tb:
                b.style.top = d + "px";
                b.style.left = c + "px";
                break;
            case Ub:
                b.style.top = d + "px";
                b.style.right = c + "px";
                break;
            case Vb:
                b.style.bottom = d + "px";
                b.style.left = c + "px";
                break;
            case 3:
                b.style.bottom = d + "px", b.style.right = c + "px"
            }
        },
        CO: function () {
            this.AO()
        },
        AO: function () {
            var a = this;
            w.F(this.A, "touchstart", function (a) {
                a.stopPropagation()
            });
            w.F(this.Ij, "click", function (b) {
                if ((b = (b.srcElement || b.target).getAttribute("data-index")) && b != a.Kc) a.cp(b), a.G.pc(a.Fj[b].panoId)
            });
            w.F(this.Dh, "mouseover", function (b) {
                b = (b.srcElement || b.target).getAttribute("data-index");
                b !== p && a.fJ(b, o)
            });
            this.G.addEventListener("size_changed", function () {
                isNaN(Number(a.k.maxWidth)) && a.dp({
                    maxWidth: a.k.maxWidth
                })
            })
        },
        cp: function (a) {
            this.Hj.style.left = this.AA[a].offsetLeft + 8 + "px";
            this.Hj.setAttribute("data-index", this.AA[a].getAttribute("data-index"));
            this.Kc = a;
            this.fJ(a)
        },
        fJ: function (a, b) {
            var c = this.ti.width + 8,
                d = 0;
            this.gj.Zr && (d = this.gj.Zr() / 2);
            var e = this.Ij.offsetWidth - 2 * d,
                f = this.Dh.offsetLeft || this.gj.x,
                f = f - d,
                g = -a * c;
            g > f && this.gj.scrollTo(g + d);
            c = g - c;
            f -= e;
            c < f && (!b || b && 8 < g - f) && this.gj.scrollTo(c + e + d)
        },
        jW: function () {
            this.gj = G() ? new we(this.Ij, {
                ur: q,
                UD: o,
                $i: q,
                ij: q,
                op: q,
                nL: o,
                nB: o,
                nD: o
            }) : new ze(this.Ij)
        },
        J: function () {
            this.A.style.visibility = "hidden"
        },
        show: function () {
            this.A.style.visibility = "visible"
        }
    });

    function ze(a) {
        this.A = a;
        this.yg = a.children[0];
        this.er = p;
        this.Ak = 20;
        this.fa()
    }
    ze.prototype = {
        fa: function () {
            this.yg.style.position = "relative";
            this.refresh();
            this.zr();
            this.yl()
        },
        refresh: function () {
            this.xn = this.A.offsetWidth - this.Zr();
            this.aA = -(this.yg.offsetWidth - this.xn - this.Ak);
            this.Ku = this.Ak;
            this.yg.style.left = this.Ku + "px";
            this.yg.children[0] && (this.er = this.yg.children[0].offsetWidth);
            this.wh && (this.wh.children[0].style.marginTop = this.Wq.children[0].style.marginTop = this.wh.offsetHeight / 2 - this.wh.children[0].offsetHeight / 2 + "px")
        },
        Zr: function () {
            return 2 * this.Ak
        },
        zr: function () {
            this.Yu = J("div");
            this.Yu.innerHTML = '<a class="pano_photo_arrow_l" href="javascript:void(0)" title="\u4e0a\u4e00\u9875"><span class="pano_arrow_l"></span></a><a class="pano_photo_arrow_r" href="javascript:void(0)" title="\u4e0b\u4e00\u9875"><span class="pano_arrow_r"></span></a>';
            this.wh = this.Yu.children[0];
            this.Wq = this.Yu.children[1];
            this.A.appendChild(this.Yu);
            this.wh.children[0].style.marginTop = this.Wq.children[0].style.marginTop = this.wh.offsetHeight / 2 - this.wh.children[0].offsetHeight / 2 + "px"
        },
        yl: function () {
            var a = this;
            w.F(this.wh, "click", function () {
                a.scrollTo(a.yg.offsetLeft + a.xn)
            });
            w.F(this.Wq, "click", function () {
                a.scrollTo(a.yg.offsetLeft - a.xn)
            })
        },
        RS: function () {
            w.B.Xb(this.wh, "pano_arrow_disable");
            w.B.Xb(this.Wq, "pano_arrow_disable");
            var a = this.yg.offsetLeft;
            a >= this.Ku && w.B.Ya(this.wh, "pano_arrow_disable");
            a - this.xn <= this.aA && w.B.Ya(this.Wq, "pano_arrow_disable")
        },
        scrollTo: function (a) {
            a = a < this.yg.offsetLeft ? Math.ceil((a - this.Ak - this.xn) / this.er) * this.er + this.xn + this.Ak - 8 : Math.ceil((a - this.Ak) / this.er) * this.er + this.Ak;
            a < this.aA ? a = this.aA : a > this.Ku && (a = this.Ku);
            var b = this.yg.offsetLeft,
                c = this;
            new tb({
                Lc: 60,
                bc: ub.nC,
                duration: 300,
                la: function (d) {
                    c.yg.style.left = b + (a - b) * d + "px"
                },
                finish: function () {
                    c.RS()
                }
            })
        }
    };
    z.Map = Ka;
    z.Hotspot = hb;
    z.MapType = Pc;
    z.Point = H;
    z.Pixel = P;
    z.Size = K;
    z.Bounds = eb;
    z.TileLayer = Cc;
    z.Projection = fc;
    z.MercatorProjection = Q;
    z.PerspectiveProjection = gb;
    z.Copyright = function (a, b, c) {
        this.id = a;
        this.Ua = b;
        this.content = c
    };
    z.Overlay = hc;
    z.Label = pc;
    z.GroundOverlay = qc;
    z.PointCollection = uc;
    z.Marker = R;
    z.Icon = lc;
    z.IconSequence = nc;
    z.Symbol = mc;
    z.Polyline = yc;
    z.Polygon = xc;
    z.InfoWindow = oc;
    z.Circle = zc;
    z.Control = Sb;
    z.NavigationControl = ib;
    z.GeolocationControl = Wb;
    z.OverviewMapControl = lb;
    z.CopyrightControl = Xb;
    z.ScaleControl = jb;
    z.MapTypeControl = mb;
    z.PanoramaControl = Zb;
    z.TrafficLayer = Mc;
    z.CustomLayer = nb;
    z.ContextMenu = bc;
    z.MenuItem = ec;
    z.LocalSearch = bb;
    z.TransitRoute = od;
    z.DrivingRoute = rd;
    z.WalkingRoute = sd;
    z.Autocomplete = zd;
    z.Geocoder = ud;
    z.LocalCity = wd;
    z.Geolocation = Geolocation;
    z.BusLineSearch = yd;
    z.Boundary = xd;
    z.VectorCloudLayer = Kc;
    z.VectorTrafficLayer = Lc;
    z.Panorama = Na;
    z.PanoramaLabel = Fd;
    z.PanoramaService = ac;
    z.PanoramaCoverageLayer = $b;
    z.PanoramaFlashInterface = Md;

    function U(a, b) {
        for (var c in b) a[c] = b[c]
    }
    U(window, {
        BMap: z,
        _jsload2: function (a, b) {
            ja.Sx.tW && ja.Sx.set(a, b);
            I.FT(a, b)
        },
        BMAP_API_VERSION: "2.0"
    });
    var V = Ka.prototype;
    U(V, {
        getBounds: V.Ld,
        getCenter: V.za,
        getMapType: V.ia,
        getSize: V.Lb,
        setSize: V.sd,
        getViewport: V.ls,
        getZoom: V.U,
        centerAndZoom: V.Zd,
        panTo: V.$h,
        panBy: V.hg,
        setCenter: V.Gf,
        setCurrentCity: V.zE,
        setMapType: V.jg,
        setViewport: V.fh,
        setZoom: V.Bc,
        highResolutionEnabled: V.Og,
        zoomTo: V.ng,
        zoomIn: V.$E,
        zoomOut: V.aF,
        addHotspot: V.Fv,
        removeHotspot: V.uX,
        clearHotspots: V.Cl,
        checkResize: V.IT,
        addControl: V.Dv,
        removeControl: V.gM,
        getContainer: V.Fa,
        addContextMenu: V.On,
        removeContextMenu: V.So,
        addOverlay: V.xa,
        removeOverlay: V.Hb,
        clearOverlays: V.cJ,
        openInfoWindow: V.zb,
        closeInfoWindow: V.Jc,
        pointToOverlayPixel: V.Ee,
        overlayPixelToPoint: V.XL,
        getInfoWindow: V.Mg,
        getOverlays: V.bD,
        getPanes: function () {
            return {
                floatPane: this.Xd.EC,
                markerMouseTarget: this.Xd.PD,
                floatShadow: this.Xd.TJ,
                labelPane: this.Xd.JD,
                markerPane: this.Xd.rL,
                markerShadow: this.Xd.sL,
                mapPane: this.Xd.Ds
            }
        },
        addTileLayer: V.Cg,
        removeTileLayer: V.dh,
        pixelToPoint: V.nb,
        pointToPixel: V.Ub,
        setFeatureStyle: V.bp,
        selectBaseElement: V.C1,
        setMapStyle: V.Xs,
        enable3DBuilding: V.fo,
        disable3DBuilding: V.nU
    });
    var Ae = Pc.prototype;
    U(Ae, {
        getTileLayer: Ae.NV,
        getMinZoom: Ae.qo,
        getMaxZoom: Ae.Sl,
        getProjection: Ae.vo,
        getTextColor: Ae.js,
        getTips: Ae.ks
    });
    U(window, {
        BMAP_NORMAL_MAP: La,
        BMAP_PERSPECTIVE_MAP: Oa,
        BMAP_SATELLITE_MAP: Xa,
        BMAP_HYBRID_MAP: Qa
    });
    var Be = Q.prototype;
    U(Be, {
        lngLatToPoint: Be.Sg,
        pointToLngLat: Be.bi
    });
    var Ce = gb.prototype;
    U(Ce, {
        lngLatToPoint: Ce.Sg,
        pointToLngLat: Ce.bi
    });
    var De = eb.prototype;
    U(De, {
        equals: De.$a,
        containsPoint: De.xr,
        containsBounds: De.TT,
        intersects: De.ts,
        extend: De.extend,
        getCenter: De.za,
        isEmpty: De.ej,
        getSouthWest: De.Ce,
        getNorthEast: De.zf,
        toSpan: De.QE
    });
    var Ee = hc.prototype;
    U(Ee, {
        isVisible: Ee.Rg,
        show: Ee.show,
        hide: Ee.J
    });
    hc.getZIndex = hc.Yl;
    var Fe = fb.prototype;
    U(Fe, {
        openInfoWindow: Fe.zb,
        closeInfoWindow: Fe.Jc,
        enableMassClear: Fe.Ti,
        disableMassClear: Fe.pU,
        show: Fe.show,
        hide: Fe.J,
        getMap: Fe.Bw,
        addContextMenu: Fe.On,
        removeContextMenu: Fe.So
    });
    var Ge = R.prototype;
    U(Ge, {
        setIcon: Ge.Ob,
        getIcon: Ge.po,
        setPosition: Ge.ha,
        getPosition: Ge.V,
        setOffset: Ge.he,
        getOffset: Ge.Af,
        getLabel: Ge.XC,
        setLabel: Ge.Bm,
        setTitle: Ge.qc,
        setTop: Ge.ei,
        enableDragging: Ge.Rb,
        disableDragging: Ge.VB,
        setZIndex: Ge.bt,
        getMap: Ge.Bw,
        setAnimation: Ge.Am,
        setShadow: Ge.Jx,
        hide: Ge.J,
        setRotation: Ge.fp,
        getRotation: Ge.oK
    });
    U(window, {
        BMAP_ANIMATION_DROP: 1,
        BMAP_ANIMATION_BOUNCE: 2
    });
    var Je = pc.prototype;
    U(Je, {
        setStyle: Je.td,
        setStyles: Je.di,
        setContent: Je.Pc,
        setPosition: Je.ha,
        getPosition: Je.V,
        setOffset: Je.he,
        getOffset: Je.Af,
        setTitle: Je.qc,
        setZIndex: Je.bt,
        getMap: Je.Bw,
        getContent: Je.Wj
    });
    var Ke = lc.prototype;
    U(Ke, {
        setImageUrl: Ke.bY,
        setSize: Ke.sd,
        setAnchor: Ke.lc,
        setImageOffset: Ke.Ws,
        setImageSize: Ke.$X,
        setInfoWindowAnchor: Ke.dY,
        setPrintImageUrl: Ke.mY
    });
    var Le = oc.prototype;
    U(Le, {
        redraw: Le.Td,
        setTitle: Le.qc,
        setContent: Le.Pc,
        getContent: Le.Wj,
        getPosition: Le.V,
        enableMaximize: Le.Gg,
        disableMaximize: Le.jw,
        isOpen: Le.Ja,
        setMaxContent: Le.Ys,
        maximize: Le.fx,
        enableAutoPan: Le.Tr
    });
    var Me = jc.prototype;
    U(Me, {
        getPath: Me.ce,
        setPath: Me.ie,
        setPositionAt: Me.Dm,
        getStrokeColor: Me.HV,
        setStrokeWeight: Me.ip,
        getStrokeWeight: Me.rK,
        setStrokeOpacity: Me.gp,
        getStrokeOpacity: Me.IV,
        setFillOpacity: Me.Vs,
        getFillOpacity: Me.gV,
        setStrokeStyle: Me.hp,
        getStrokeStyle: Me.qK,
        getFillColor: Me.fV,
        getBounds: Me.Ld,
        enableEditing: Me.xf,
        disableEditing: Me.oU
    });
    var Ne = zc.prototype;
    U(Ne, {
        setCenter: Ne.Gf,
        getCenter: Ne.za,
        getRadius: Ne.mK,
        setRadius: Ne.af
    });
    var Oe = xc.prototype;
    U(Oe, {
        getPath: Oe.ce,
        setPath: Oe.ie,
        setPositionAt: Oe.Dm
    });
    var Pe = hb.prototype;
    U(Pe, {
        getPosition: Pe.V,
        setPosition: Pe.ha,
        getText: Pe.gD,
        setText: Pe.at
    });
    H.prototype.equals = H.prototype.$a;
    P.prototype.equals = P.prototype.$a;
    K.prototype.equals = K.prototype.$a;
    U(window, {
        BMAP_ANCHOR_TOP_LEFT: Tb,
        BMAP_ANCHOR_TOP_RIGHT: Ub,
        BMAP_ANCHOR_BOTTOM_LEFT: Vb,
        BMAP_ANCHOR_BOTTOM_RIGHT: 3
    });
    var Qe = Sb.prototype;
    U(Qe, {
        setAnchor: Qe.lc,
        getAnchor: Qe.KC,
        setOffset: Qe.he,
        getOffset: Qe.Af,
        show: Qe.show,
        hide: Qe.J,
        isVisible: Qe.Rg,
        toString: Qe.toString
    });
    var Re = ib.prototype;
    U(Re, {
        getType: Re.zo,
        setType: Re.Em
    });
    U(window, {
        BMAP_NAVIGATION_CONTROL_LARGE: 0,
        BMAP_NAVIGATION_CONTROL_SMALL: 1,
        BMAP_NAVIGATION_CONTROL_PAN: 2,
        BMAP_NAVIGATION_CONTROL_ZOOM: 3
    });
    var Se = lb.prototype;
    U(Se, {
        changeView: Se.$d,
        setSize: Se.sd,
        getSize: Se.Lb
    });
    var Te = jb.prototype;
    U(Te, {
        getUnit: Te.RV,
        setUnit: Te.FE
    });
    U(window, {
        BMAP_UNIT_METRIC: "metric",
        BMAP_UNIT_IMPERIAL: "us"
    });
    var Ue = Xb.prototype;
    U(Ue, {
        addCopyright: Ue.Ev,
        removeCopyright: Ue.lE,
        getCopyright: Ue.Ql,
        getCopyrightCollection: Ue.RC
    });
    U(window, {
        BMAP_MAPTYPE_CONTROL_HORIZONTAL: Yb,
        BMAP_MAPTYPE_CONTROL_DROPDOWN: 1,
        BMAP_MAPTYPE_CONTROL_MAP: 2
    });
    var Ve = Cc.prototype;
    U(Ve, {
        getMapType: Ve.ia,
        getCopyright: Ve.Ql,
        isTransparentPng: Ve.As
    });
    var We = bc.prototype;
    U(We, {
        addItem: We.Gv,
        addSeparator: We.aB,
        removeSeparator: We.nE
    });
    var Xe = ec.prototype;
    U(Xe, {
        setText: Xe.at
    });
    var Ye = T.prototype;
    U(Ye, {
        getStatus: Ye.Vl,
        setSearchCompleteCallback: Ye.DE,
        getPageCapacity: Ye.Ve,
        setPageCapacity: Ye.ep,
        setLocation: Ye.Cm,
        disableFirstResultSelection: Ye.WB,
        enableFirstResultSelection: Ye.tC,
        gotoPage: Ye.Zl,
        searchNearby: Ye.$o,
        searchInBounds: Ye.zm,
        search: Ye.search
    });
    U(window, {
        BMAP_STATUS_SUCCESS: 0,
        BMAP_STATUS_CITY_LIST: 1,
        BMAP_STATUS_UNKNOWN_LOCATION: 2,
        BMAP_STATUS_UNKNOWN_ROUTE: 3,
        BMAP_STATUS_INVALID_KEY: 4,
        BMAP_STATUS_INVALID_REQUEST: 5,
        BMAP_STATUS_PERMISSION_DENIED: 6,
        BMAP_STATUS_SERVICE_UNAVAILABLE: 7,
        BMAP_STATUS_TIMEOUT: 8
    });
    U(window, {
        BMAP_POI_TYPE_NORMAL: 0,
        BMAP_POI_TYPE_BUSSTOP: 1,
        BMAP_POI_TYPE_BUSLINE: 2,
        BMAP_POI_TYPE_SUBSTOP: 3,
        BMAP_POI_TYPE_SUBLINE: 4
    });
    U(window, {
        BMAP_TRANSIT_POLICY_LEAST_TIME: 0,
        BMAP_TRANSIT_POLICY_LEAST_TRANSFER: 2,
        BMAP_TRANSIT_POLICY_LEAST_WALKING: 3,
        BMAP_TRANSIT_POLICY_AVOID_SUBWAYS: 4,
        BMAP_LINE_TYPE_BUS: 0,
        BMAP_LINE_TYPE_SUBWAY: 1,
        BMAP_LINE_TYPE_FERRY: 2
    });
    var Ze = nd.prototype;
    U(Ze, {
        clearResults: Ze.ze
    });
    pd = od.prototype;
    U(pd, {
        setPolicy: pd.$s,
        toString: pd.toString,
        setPageCapacity: pd.ep
    });
    U(window, {
        BMAP_DRIVING_POLICY_LEAST_TIME: 0,
        BMAP_DRIVING_POLICY_LEAST_DISTANCE: 1,
        BMAP_DRIVING_POLICY_AVOID_HIGHWAYS: 2
    });
    U(window, {
        BMAP_HIGHLIGHT_STEP: 1,
        BMAP_HIGHLIGHT_ROUTE: 2
    });
    U(window, {
        BMAP_ROUTE_TYPE_DRIVING: $c,
        BMAP_ROUTE_TYPE_WALKING: Zc
    });
    U(window, {
        BMAP_ROUTE_STATUS_NORMAL: ad,
        BMAP_ROUTE_STATUS_EMPTY: 1,
        BMAP_ROUTE_STATUS_ADDRESS: 2
    });
    var $e = rd.prototype;
    U($e, {
        setPolicy: $e.$s
    });
    var af = zd.prototype;
    U(af, {
        show: af.show,
        hide: af.J,
        setTypes: af.EE,
        setLocation: af.Cm,
        search: af.search,
        setInputValue: af.Gx
    });
    U(nb.prototype, {});
    var bf = xd.prototype;
    U(bf, {
        get: bf.get
    });
    U($b.prototype, {});
    U(cb.prototype, {});
    U(window, {
        BMAP_POINT_DENSITY_HIGH: 200,
        BMAP_POINT_DENSITY_MEDIUM: Oc,
        BMAP_POINT_DENSITY_LOW: 50
    });
    U(window, {
        BMAP_POINT_SHAPE_STAR: 1,
        BMAP_POINT_SHAPE_WATERDROP: 2,
        BMAP_POINT_SHAPE_CIRCLE: rc,
        BMAP_POINT_SHAPE_SQUARE: 4,
        BMAP_POINT_SHAPE_RHOMBUS: 5
    });
    U(window, {
        BMAP_POINT_SIZE_TINY: 1,
        BMAP_POINT_SIZE_SMALLER: 2,
        BMAP_POINT_SIZE_SMALL: 3,
        BMAP_POINT_SIZE_NORMAL: sc,
        BMAP_POINT_SIZE_BIG: 5,
        BMAP_POINT_SIZE_BIGGER: 6,
        BMAP_POINT_SIZE_HUGE: 7
    });
    U(window, {
        BMap_Symbol_SHAPE_CAMERA: 11,
        BMap_Symbol_SHAPE_WARNING: 12,
        BMap_Symbol_SHAPE_SMILE: 13,
        BMap_Symbol_SHAPE_CLOCK: 14,
        BMap_Symbol_SHAPE_POINT: 9,
        BMap_Symbol_SHAPE_PLANE: 10,
        BMap_Symbol_SHAPE_CIRCLE: 1,
        BMap_Symbol_SHAPE_RECTANGLE: 2,
        BMap_Symbol_SHAPE_RHOMBUS: 3,
        BMap_Symbol_SHAPE_STAR: 4,
        BMap_Symbol_SHAPE_BACKWARD_CLOSED_ARROW: 5,
        BMap_Symbol_SHAPE_FORWARD_CLOSED_ARROW: 6,
        BMap_Symbol_SHAPE_BACKWARD_OPEN_ARROW: 7,
        BMap_Symbol_SHAPE_FORWARD_OPEN_ARROW: 8
    });
    U(window, {
        BMAP_CONTEXT_MENU_ICON_ZOOMIN: cc,
        BMAP_CONTEXT_MENU_ICON_ZOOMOUT: dc
    });
    z.iT();
})()