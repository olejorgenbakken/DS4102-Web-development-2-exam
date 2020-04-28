<template>
  <section class="settings card">
    <header>
      <h2>Farger</h2>
    </header>
    <ColorPickerList></ColorPickerList>
  </section>
</template>

<script>
import ColorPickerList from "./SettingsAssets/ColorPickerList";
export default {
  name: "Settings",
  components: {
    ColorPickerList
  }
};
</script>

<style scoped>
.settings {
  padding: 20px;
  display: flex;
  flex-direction: column;
}

.settings header {
  margin-bottom: 10px;
}
</style>