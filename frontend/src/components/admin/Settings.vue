<template>
  <section class="settings card">
    <header>
      <h2>Innstillinger</h2>
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
  display: grid;
  grid-template-columns: 1fr;
  gap: 15px;
}
</style>