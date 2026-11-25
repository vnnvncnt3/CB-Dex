const defaultTheme = require("tailwindcss/defaultTheme");

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Cardbooth/**/*.{razor,html,cs}",
    "./Cardbooth.Client/**/*.{razor,html,cs}",
    "!./**/bin/**",
    "!./**/obj/**",
  ],
  theme: {
    extend: {
      fontFamily: {
        sans: ["Inter", ...defaultTheme.fontFamily.sans],
      },
      colors: {
        accent: "#F5C518",
        holiday: {
          red: "#C8102E",
          green: "#1E7A4D",
          gold: "#F2B84B",
        },
        type: {
          colorless: { DEFAULT: "#B8B8C0", soft: "#EFEFF2" },
          grass: { DEFAULT: "#5FB04A", soft: "#E3F3DC" },
          fire: { DEFAULT: "#EF5B3C", soft: "#FDE4DD" },
          water: { DEFAULT: "#3B9AE1", soft: "#DCEEFB" },
          lightning: { DEFAULT: "#F5C518", soft: "#FEF5CC" },
          psychic: { DEFAULT: "#8E4FC4", soft: "#EBDDF7" },
          fighting: { DEFAULT: "#C2703A", soft: "#F5E3D3" },
          darkness: { DEFAULT: "#3F3F46", soft: "#D4D4D8" },
          metal: { DEFAULT: "#8A97A6", soft: "#E4E8ED" },
          fairy: { DEFAULT: "#EE7FB6", soft: "#FCE4F0" },
          ice: { DEFAULT: "#7FD3E8", soft: "#E0F5FA" },
        },
      },
    },
  },
  plugins: [],
};