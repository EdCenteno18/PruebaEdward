import gulp from 'gulp';
import plumber from 'gulp-plumber';
import browserSync from 'browser-sync';
import sass from 'gulp-sass';
import postcss from 'gulp-postcss';
import cssnano from 'cssnano';
import watch from 'gulp-watch';
import browserify from 'browserify';
import babelify from 'babelify';
import source from 'vinyl-source-stream';
import sourcemaps from 'gulp-sourcemaps';
import buffer from 'vinyl-buffer';
import cleanCSS from 'gulp-clean-css';
import stripCssComments from 'gulp-strip-css-comments';
import cssmin from 'gulp-cssmin';
// import moduleImporter from 'sass-module-importer';
const server = browserSync.create();
const dir = {
  src   : 'src',
  dist  : 'dist',
};
const postcssPlugins =[
	cssnano({
		core: false,
		autoprefixer: {
			add: true,
			browsers: [
				'Android 2.3',
				'Android >= 4',
				'Chrome >= 20',
				'Firefox >= 24',
				'Explorer >= 8',
				'iOS >= 6',
				'Opera >= 12',
				'Safari >= 6'
			]
		}
	})
];
const sassOptions = {
	outputStyle: 'expanded',
	includePaths: ['node_modules']
};
gulp.task('styles', () =>
  gulp.src(`${dir.src}/scss/styles.scss`)
	.pipe(sourcemaps.init({ loadMaps: true }))
	.pipe(plumber())
	.pipe(sass(sassOptions).on('error', sass.logError))
	  .pipe(cssmin())
	  .pipe(cleanCSS({
		  advanced: false,
		  keepBreaks: false,
		  keepSpecialComments: 0,
		  compatibility: ''
	  }))
	  .pipe(stripCssComments({
		  preserve: false
	  }))
	.pipe(postcss(postcssPlugins))
	.pipe(sourcemaps.write('.'))
	.pipe(gulp.dest(`${dir.dist}/css/`))
	.pipe(server.stream({match: '**/*.css'}))
);
gulp.task('scripts', () =>
  browserify(`${dir.src}/js/index.js`)
    .transform(babelify)
    .bundle()
    .on('error', function(err){
      console.error(err);
      this.emit('end')
    })
    .pipe(source('scripts.js'))
    .pipe(buffer())
    .pipe(sourcemaps.init({ loadMaps: true }))
    .pipe(sourcemaps.write('.'))
    .pipe(gulp.dest(`${dir.dist}/js`))
);
gulp.task('load:dist'		, ['styles', 'scripts'],() => {

	watch(`${dir.src}/scss/**/*.scss`  , () => gulp.start('styles'));
	watch(`${dir.src}/js/**/*.js`      , () => gulp.start('scripts',server.reload));
});
