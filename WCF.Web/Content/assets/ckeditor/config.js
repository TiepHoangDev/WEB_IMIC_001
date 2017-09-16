/**
 * @license Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.extraAllowedContent = 'u em strong';
    config.extraAllowedContent = 'style;*[id];*(*);*{*}';
    config.extraAllowedContent = 'p(*)[*]{*};div(*)[*]{*};li(*)[*]{*};ul(*)[*]{*};span(*)[*]{*};a(*)[*]{*};table(*)[*]{*};td(*)[*]{*};tr(*)[*]{*};abbr(*)[*]{*}';
    config.extraPlugins = "lineutils,widget,codesnippet,prism,abbr,fbcomment";
    //config.extraPlugins = 'fbcomment';
    // ALLOW <i></i>
    config.protectedSource.push(/<i[^>]*><\/i>/g);
};
