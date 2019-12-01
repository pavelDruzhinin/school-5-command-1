<template>
  <v-app>
    <v-app-bar app>
      <v-toolbar-title class="headline text-uppercase">
        <router-link to="/" style="text-decoration: none; color: white">
          <span>HOME</span>
        </router-link>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <span><registration-form></registration-form></span>
    </v-app-bar>

    <v-content>
      <router-view>
        <Index />
      </router-view>
    </v-content>

    <Footer />
  </v-app>
</template>

<script>
import Index from "./components/Index";
import Footer from "./components/Footer";
import RegistrationForm from "./components/RegistrationForm";


export default {
  name: "App",

  components: {
    Footer,
    Index,
    RegistrationForm

  },

  data: () => ({
    //
  })
};
</script>
