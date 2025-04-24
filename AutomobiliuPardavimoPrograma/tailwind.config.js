const colors = require('tailwindcss/colors');

module.exports = {
  content: ['./**/*.html', './**/*.razor'],
  theme: {
    extend: {
      colors,
    },
  },
  plugins: [],
};
