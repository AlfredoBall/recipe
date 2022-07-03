import React from 'react'
import { Navigate, Outlet } from 'react-router-dom'

export default function PublicRoutes() {

  const allowAnoynymousAlways = true;
  
  return allowAnoynymousAlways ? <Outlet/> : <Navigate to="/" />;
}
