var config = {
    api: 'http://localhost:8088/api/'
};

/**
 * 获取url参数
 * @param {string} name 参数名
 * @returns {string} 参数值
 */
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}