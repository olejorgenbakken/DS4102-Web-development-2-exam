<template>
  <v-card class="mx-auto" max-width="400">
    <v-img :src="photo" height="200px"></v-img>
    <v-card-title>
      <h2 class="display-1">{{name}}</h2>
      <v-spacer></v-spacer>
      <span class="title">{{price}} kr</span>
    </v-card-title>

    <v-card-text>{{description}}</v-card-text>

    <v-card-text v-if="packs">
      <span class="subheading">Velg antall</span>

      <v-chip-group active-class="deep-purple--text text--accent-4">
        <v-chip v-for="i in packSize" :key="i">{{i*2}} stk: {{price + ((i - 1) * 30)}} kr</v-chip>
      </v-chip-group>
    </v-card-text>

    <v-card-actions class="button">
      <v-btn block class="white--text" color="deep-purple accent-4">Add to Cart</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  name: "Dish",
  props: {
    id: Number,
    name: String,
    description: String,
    price: Number,
    photo: String,
    ingredients: Array,
    packs: Boolean,
    packSize: Number
  }
};
</script>