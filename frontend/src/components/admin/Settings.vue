<template>
  <section class="settings">
    <ColorPickerList></ColorPickerList>
    <DishTypes></DishTypes>
  </section>
</template>

<script>
import ColorPickerList from "./SettingsAssets/ColorPickerList";
import DishTypes from "./SettingsAssets/DishTypes";
export default {
  name: "Settings",
  components: {
    ColorPickerList,
    DishTypes
  }
};
</script>

<style scoped>
.settings {
  display: grid;
  gap: 20px;
}
</style>