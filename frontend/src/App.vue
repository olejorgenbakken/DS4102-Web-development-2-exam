<template>
  <v-app>
    <router-view></router-view>
  </v-app>
</template>

<script>
export default {
  name: "App"
};
</script>

<style>
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

.header {
  width: 100%;
  text-align: center;
  padding: 80px 0 40px 0;
}

.title {
  font-size: 2.5em;
}
</style>