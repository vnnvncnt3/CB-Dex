/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Cardbooth/**/*.{razor,html,cs}",
    "./Cardbooth.Client/**/*.{razor,html,cs}",
    "!./**/bin/**",
    "!./**/obj/**",
  ],
  theme: {
    extend: {},
  },
  plugins: [],
};