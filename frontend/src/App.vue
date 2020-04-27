<template>
  <main>
    <TheHeader :sitetitle="sitetitle"></TheHeader>
    <router-view></router-view>
    <TheFooter :sitetitle="sitetitle"></TheFooter>
  </main>
</template>

<script>
import TheHeader from "./components/TheHeader";
import TheFooter from "./components/TheFooter";

export default {
  name: "App",
  components: {
    TheHeader,
    TheFooter
  },
  data() {
    return {
      settings: {},
      sitetitle: "Oslo Sushi"
    };
  }
};
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat:500,700,900|Roboto:400&display=swap");
:root {
  --heading: "Montserrat", sans-serif;
  --paragraph: "Roboto", sans-serif;
  --background: #ffffff;
  --card-background: #f7f7f7;
  --text: #000000;
  --links: rgb(0, 0, 218);
  --footer: #f0f0f0;
}

* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
  scroll-behavior: smooth;
}

body {
  background-color: var(--background);
  color: var(--text);
}

h1,
h2,
h3,
h4,
h5,
a {
  font-family: var(--heading);
}

a {
  color: var(--links);
  text-decoration: none;
}

h1 {
  font-weight: 900;
}

h2 {
  font-weight: 700;
}

p,
textarea,
label,
small,
input {
  font-family: var(--paragraph);
}

small {
  font-weight: 400;
}

img {
  max-width: 100%;
  background: var(--footer);
  color: var(--text);
}

a,
button,
input[type="file"],
input[type="color"] {
  cursor: pointer;
}

button {
  padding: 7px 20px;
  font-size: 1em;
  border: none;
  border-radius: 0;
  outline: none;
  background-color: var(--text);
  color: var(--background);
  font-weight: 700;
  font-family: var(--heading);
  width: 100%;
}

.del-btn {
  background: red;
  color: white;
}

.del-text {
  color: rgb(250, 58, 58);
  font-weight: 700;
  cursor: pointer;
}

input[type="text"],
input[type="search"],
input[type="number"],
input[type="password"],
input[type="color"],
input[type="file"],
input[type="month"],
select,
textarea,
label.input {
  width: 100%;
  padding: 5px 3px;
  margin-top: 3px;
  font-size: 1em;
  height: 100%;
}

input[type="text"],
input[type="search"],
input[type="number"],
input[type="password"],
input[type="color"],
input[type="month"],
select {
  border: none;
}

input[type="text"],
input[type="search"],
input[type="number"],
input[type="password"],
input[type="month"],
select,
textarea,
label.input {
  background-color: var(--background);
  color: var(--text);
}

input[type="text"],
input[type="search"],
input[type="number"],
input[type="password"],
input[type="month"],
select {
  border-bottom: 1px solid var(--text);
}

input[type="file"],
input[type="color"] {
  z-index: 1;
}

input[type="color"] {
  padding: 0;
  margin: 0;
  height: 35px;
  background: transparent;
}

input,
select {
  border-radius: 0;
}

label {
  font-family: var(--heading);
  font-size: 0.9em;
}

label.hint {
  margin: 2px 0 0 2px;
  font-size: 0.8em;
}

label.type {
  font-family: var(--heading);
  font-size: 0.8em;
  letter-spacing: 1px;
  padding: 4px 10px;
  border-radius: 5px;
  font-weight: 900;
  text-transform: uppercase;
  background: var(--text);
  color: var(--background);
}

textarea {
  min-height: 50px;
  resize: vertical;
}

select[multiple] {
  border: 1px solid var(--text);
  padding: 0;
  height: 100px;
  overflow: auto;
}

option {
  padding: 5px 2px;
  background: var(--background);
  border-bottom: 1px solid var(--footer);
  transition: 0.3s ease-in-out;
}

option:hover {
  background: var(--footer);
}

figure {
  overflow: hidden;
  position: relative;
}

figure img {
  position: absolute;
  height: 100%;
  width: 100%;
  object-fit: cover;
  left: 0;
  top: 0;
}

form section {
  display: flex;
  flex-direction: column;
}

.card {
  position: relative;
  z-index: 1;
  transition: 0.1s ease-in-out;
  color: var(--text);
}

.card::before {
  filter: blur(10px);
  content: "";
  position: absolute;
  left: -10px;
  top: -10px;
  width: calc(100% + 20px);
  height: calc(100% + 20px);
  z-index: -1;
}

.card::after {
  content: "";
  position: absolute;
  left: 0;
  top: 0;
  right: 0;
  bottom: 0;
  z-index: -1;
  background: var(--card-background);
}

.card:hover,
.shadow {
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.05), 0 1px 8px rgba(0, 0, 0, 0.1);
}

footer {
  background: var(--footer);
  color: var(--text);
}

@media screen and (prefers-color-scheme: dark) {
  :root {
    --background: #202020;
    --card-background: #111111;
    --text: #f5f5f5;
    --links: rgb(85, 139, 255);
    --footer: #141414;
  }

  .card:hover,
  .shadow {
    box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2), 0 1px 8px rgba(0, 0, 0, 0.75);
  }
}
</style>